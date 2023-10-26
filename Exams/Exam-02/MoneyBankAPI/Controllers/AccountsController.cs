using System;
using System.Collections.Generic;
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
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private const decimal MAX_OVERDRAFT = 1000000M;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            // ESto Podria ir en otra Funcion por que ademas Rompe SOLID
            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool AccountExist(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'AppDbContext.Accounts'  is null.");
            }

            if (AccountExists(account.AccountNumber))
            {
                return BadRequest($"La cuenta {account.AccountNumber} ya existe.");
            }

            if (account.BalanceAmount <= 0)
            {
                return BadRequest("El balance debe ser mayor que 0.");
            }

            // El Crear Cuenta deberia ir en Otra Funcion, Adicional Rompe SOLID
            if (account.AccountType == 'C')
            {
                account.BalanceAmount += MAX_OVERDRAFT;
            }

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DEPOSITO: PUT/api/Accounts/{id}/Deposit

        [HttpPut("{id}/Deposit")]
        public async Task<IActionResult> Deposit(int id, Transaction depositTransaction)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound($"La cuenta con ID {id} no existe.");
            }

            if (account.AccountNumber != depositTransaction.AccountNumber)
            {
                return BadRequest($"La cuenta {depositTransaction.AccountNumber} no existe.");
            }

            if (depositTransaction.ValueAmount <= 0)
            {
                return BadRequest("El monto del depósito debe ser mayor que 0.");
            }

            // Esto deberia ir en Otra Funcion 
            account.BalanceAmount += depositTransaction.ValueAmount;

            if (account.AccountType == 'C')
            {
                if (account.OverdraftAmount > 0 && account.BalanceAmount < MAX_OVERDRAFT)
                {
                    account.OverdraftAmount = MAX_OVERDRAFT - account.BalanceAmount;
                }
                else
                {
                    account.OverdraftAmount = 0;
                }
            }

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



        // RETIRO: PUT/api/Accounts/{id}/Withdrawal
        [HttpPut("{id}/Withdrawal")]
        public async Task<IActionResult> Withdrawal(int id, Transaction withdrawalTransaction)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound($"La cuenta con ID {id} no existe.");
            }

            if (!AccountExists(withdrawalTransaction.AccountNumber))
            {
                return BadRequest($"La cuenta {withdrawalTransaction.AccountNumber} no existe.");
            }

            if (withdrawalTransaction.ValueAmount <= 0)
            {
                return BadRequest("El monto del retiro debe ser mayor que 0.");
            }

            // Esta Lofica deberia ir en Ora Funcion, Tambien Rompe SOLID
            if (withdrawalTransaction.ValueAmount <= account.BalanceAmount)
            {
                account.BalanceAmount -= withdrawalTransaction.ValueAmount;

                if (account.AccountType == 'C' && account.BalanceAmount < MAX_OVERDRAFT)
                {
                    account.OverdraftAmount = MAX_OVERDRAFT - account.BalanceAmount;
                }
            }
            else
            {
                return BadRequest("Fondos insuficientes.");
            }


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


    private bool AccountExists(string accountNumber)
        {
            return (_context.Accounts?.Any(e => e.AccountNumber == accountNumber)).GetValueOrDefault();
        }

    }
}

