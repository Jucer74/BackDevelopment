using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBankAPI.Context;
using MoneyBankAPI.Models;

namespace MoneyBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccounts : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private const decimal MaxOverdraft = 1000000M;

        public BankAccounts(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult> ListAccounts()
        {
            var accounts = await _ctx.Accounts.ToListAsync();
            return accounts.Any() ? Ok(accounts) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAccount(int id)
        {
            var account = await _ctx.Accounts.FindAsync(id);
            return account != null ? Ok(account) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _ctx.Entry(account).State = EntityState.Modified;

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _ctx.Accounts.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(Account account)
        {
            if (AccountExists(account.AccountNumber))
            {
                return BadRequest($"Cuenta {account.AccountNumber} ya existe.");
            }

            if (account.BalanceAmount <= 0)
            {
                return BadRequest("Balance debe ser mayor que 0.");
            }

            if (account.AccountType == 'C')
            {
                account.BalanceAmount += MaxOverdraft;
            }

            _ctx.Accounts.Add(account);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _ctx.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _ctx.Accounts.Remove(account);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/Deposit")]
        public async Task<IActionResult> DepositFunds(int id, Transaction depositTransaction)
        {
            var account = await _ctx.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound($"Cuenta con ID {id} no existe.");
            }

            if (account.AccountNumber != depositTransaction.AccountNumber)
            {
                return BadRequest($"Cuenta {depositTransaction.AccountNumber} no existe.");
            }

            if (depositTransaction.ValueAmount <= 0)
            {
                return BadRequest("Monto del depósito debe ser mayor que 0.");
            }

            account.BalanceAmount += depositTransaction.ValueAmount;

            if (account.AccountType == 'C')
            {
                if (account.OverdraftAmount > 0 && account.BalanceAmount < MaxOverdraft)
                {
                    account.OverdraftAmount = MaxOverdraft - account.BalanceAmount;
                }
                else
                {
                    account.OverdraftAmount = 0;
                }
            }

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPut("{id}/Withdrawal")]
        public async Task<IActionResult> WithdrawFunds(int id, Transaction withdrawalTransaction)
        {
            var account = await _ctx.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound($"Cuenta con ID {id} no existe.");
            }

            if (!AccountExists(withdrawalTransaction.AccountNumber))
            {
                return BadRequest($"Cuenta {withdrawalTransaction.AccountNumber} no existe.");
            }

            if (withdrawalTransaction.ValueAmount <= 0)
            {
                return BadRequest("Monto del retiro debe ser mayor que 0.");
            }

            if (withdrawalTransaction.ValueAmount <= account.BalanceAmount)
            {
                account.BalanceAmount -= withdrawalTransaction.ValueAmount;

                if (account.AccountType == 'C' && account.BalanceAmount < MaxOverdraft)
                {
                    account.OverdraftAmount = MaxOverdraft - account.BalanceAmount;
                }
            }
            else
            {
                return BadRequest("Fondos insuficientes.");
            }

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        private bool AccountExists(object accountNumber)
        {
            throw new NotImplementedException();
        }

        private bool AccountExists(string accountNumber)
        {
            return _ctx.Accounts.Any(e => e.AccountNumber == accountNumber);
        }
    }
}
