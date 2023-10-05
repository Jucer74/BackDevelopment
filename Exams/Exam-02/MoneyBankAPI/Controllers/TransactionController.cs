using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBankAPI.Models;

namespace MoneyBankAPI.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class TransactionController:ControllerBase 
	{
        private readonly AppDbContext _context;

        private readonly double MAX_OVERDRAFT = 1_000_000;

        private readonly char CORRIENTE = 'C';

        public TransactionController(AppDbContext context)
		{
            _context = context;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Deposit")]
        public async Task<IActionResult> PutDeposit(int id,Transaction transaction)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accounts.ToListAsync();
            Account accountTransaction=null!;
            bool isFound = false;

            foreach(var account in accounts)
            {
                if (account.AccountNumber == transaction.AccountNumber) {
                    accountTransaction = account;
                    isFound = true;
                }
            }

            if (!isFound)
            {
                return BadRequest("La cuenta "+ transaction.AccountNumber+" no existe");
            }
            else {

                if (accountTransaction.AccountType == CORRIENTE)
                {
                    accountTransaction.BalanceAmount += transaction.ValueAmount;

                    if (accountTransaction.OverdraftAmount > 0 && accountTransaction.BalanceAmount < MAX_OVERDRAFT)
                    {
                        accountTransaction.OverdraftAmount = MAX_OVERDRAFT - accountTransaction.BalanceAmount;
                    }
                    else
                    {
                        accountTransaction.OverdraftAmount = 0;
                    }
                }
                else {
                    accountTransaction.BalanceAmount += transaction.ValueAmount;
                }
                
            }


            _context.Entry(accountTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/WithDrawal")]
        public async Task<IActionResult> PutWithDrawal(int id, Transaction transaction)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accounts.ToListAsync();
            Account accountTransaction = null!;
            bool isFound = false;

            foreach (var account in accounts)
            {
                if (account.AccountNumber == transaction.AccountNumber)
                {
                    accountTransaction = account;
                    isFound = true;
                }
            }

            if (!isFound)
            {
                return BadRequest("La cuenta " + transaction.AccountNumber + " no existe");
            }
            else
            {
                if (accountTransaction.AccountType == CORRIENTE)
                {
                    if (transaction.ValueAmount <= accountTransaction.BalanceAmount)
                    {
                        accountTransaction.BalanceAmount -= transaction.ValueAmount;

                        if (accountTransaction.OverdraftAmount >= 0 && accountTransaction.BalanceAmount < MAX_OVERDRAFT)
                        {
                            accountTransaction.OverdraftAmount = MAX_OVERDRAFT - accountTransaction.BalanceAmount;
                        }
                    }
                    else
                    {
                        return BadRequest("Fondos Insuficientes");
                    }
                }
                else
                {
                    if (transaction
                        .ValueAmount<= accountTransaction.BalanceAmount)
                    {
                        accountTransaction.BalanceAmount -= transaction.ValueAmount;
}
                    else
                    {
                        return BadRequest("Fondos insuficientes");
                    }
                }
            }


            _context.Entry(accountTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

    }
}
