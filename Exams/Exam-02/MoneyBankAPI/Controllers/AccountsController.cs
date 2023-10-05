using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBankAPI.Models;

namespace MoneyBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
	{
        private readonly AppDbContext _context;
        private readonly Double MAX_OVERDRAFT = 1_000_000;
        private readonly char CORRIENTE = 'C';

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
            var Account = await _context.Accounts.FindAsync(id);

            if (Account == null)
            {
                return NotFound();
            }


            return Account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account Account)
        {
            var accounts = await _context.Accounts.ToListAsync();
            bool isFound = false;
            foreach (var account in accounts)
            {
                if (account.AccountNumber == Account.AccountNumber)
                {
                    isFound = true;
                }
            }
            if (!isFound) {
                return BadRequest("La cuenta "+Account.AccountNumber +" no existe");
            }
            if (Account.BalanceAmount <= 0)
            {
                return BadRequest("el balance debe ser mayor a 0");
            }
            if (Account.OverdraftAmount < 0 || Account.OverdraftAmount > MAX_OVERDRAFT)
            {
                return BadRequest("el sobregiro debe estar entre 0 y " + MAX_OVERDRAFT);
            }

            if (id != Account.Id)
            {
                return BadRequest();
            }

            _context.Entry(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account Account)
        {

            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accounts.ToListAsync();
            foreach(var account in accounts)
            {
                if (account.AccountNumber == Account.AccountNumber)
                {
                    return NotFound("La cuenta " + Account.AccountNumber + " ya existe");
                }
            }
            if (Account.BalanceAmount <= 0)
            {
                return BadRequest("el balance debe ser mayor a 0");
            }
            if (Account.OverdraftAmount < 0 || Account.OverdraftAmount> MAX_OVERDRAFT)
            {
                return BadRequest("el sobregiro debe estar entre 0 y " + MAX_OVERDRAFT);
            }

            if (Account.AccountType == CORRIENTE) {
                Account.BalanceAmount += MAX_OVERDRAFT;
            }

            if (_context.Accounts == null)
            {
                return Problem("Entity set 'AppdbContext.Accounts'  is null.");
            }
            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = Account.Id }, Account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var Account = await _context.Accounts.FindAsync(id);
            if (Account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(Account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

