using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBankAPI.Models;
using MoneyBankAPI.Context;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MoneyBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

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
            var accountExists = _context.Accounts.FirstOrDefault(c => c.Id == id);
            if(accountExists == null)
            {
                return BadRequest($"La Cuenta {id} no Existe");
            }

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
            Transaction transaction = new();
            var accountExists = _context.Accounts.FirstOrDefault(c => c.Id == account.Id);
            if(accountExists == null)
            {
                return BadRequest($"La Cuenta {account.Id} no Existe");
            }
            var accountTypeSelect = account.AccountType;

            if (id != account.Id)
            {
                return BadRequest();
            }

            if (account.AccountType == 'A')
            {
                account.BalanceAmount += transaction.ValueAmount;
            }else if(account.AccountType == 'C')
            {
                account.BalanceAmount += transaction.ValueAmount;
                if(account.OverdraftAmount > 0 & account.BalanceAmount < (Decimal) Constans.MAX_OVERDRAFT)
                {
                    account.OverdraftAmount = (Decimal) Constans.MAX_OVERDRAFT - account.BalanceAmount;
                }
            }

            if(accountTypeSelect == 'C')
            {
                account.BalanceAmount = account.BalanceAmount + account.OverdraftAmount;
            }
            _context.Entry(account).State = EntityState.Modified;

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
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            
            var accountExists = _context.Accounts.FirstOrDefault(c => c.AccountNumber == account.AccountNumber);
            if(accountExists != null)
            {
                return BadRequest($"La Cuenta {account.AccountNumber} ya Existe");
            }

            if (_context.Accounts == null)
            {
                return Problem("Entity set 'AppdbContext.Accounts'  is null.");
            }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var accountExists = _context.Accounts.FirstOrDefault(c => c.Id == id);
            if(accountExists == null)
            {
                return BadRequest($"La Cuenta {id} no Existe");
            }
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

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}