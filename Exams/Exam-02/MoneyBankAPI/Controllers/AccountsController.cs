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

            if (account.AccountType == Constants.ACCOUNT_TYPE_SAVINGS)
            {
                account.BalanceAmount += transaction.ValueAmount;
            }else if(account.AccountType == Constants.ACCOUNT_TYPE_CHEKING)
            {
                account.BalanceAmount += transaction.ValueAmount;
                if(account.OverdraftAmount > Constants.ZERO & account.BalanceAmount < (Decimal) Constants.MAX_OVERDRAFT)
                {
                    account.OverdraftAmount = (Decimal) Constants.MAX_OVERDRAFT - account.BalanceAmount;
                }
            }

            if(accountTypeSelect == Constants.ACCOUNT_TYPE_CHEKING)
            {
                account.BalanceAmount = account.BalanceAmount + account.OverdraftAmount;
            }

            //Debe retornar un BadRequest con el Mensaje de "Fondos Insificientes" si al momento de retirar el valor de 
            //Retiro es superior al Valor actual del Balance
            if(transaction.ValueAmount > account.BalanceAmount)
            {
                return BadRequest();
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