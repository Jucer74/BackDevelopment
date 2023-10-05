﻿using System;
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

        // Define el valor máximo de sobregiro
        private const decimal MAX_OVERDRAFT = 1000000.00M;

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
            if (!AccountExists(id))
            {
                return BadRequest($"La Cuenta {id} No Existe");
            }

            if (id != account.Id)
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
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'AppDbContext.Accounts' is null.");
            }

            if (account.BalanceAmount <= 0)
            {
                return BadRequest("El Balance debe ser mayor a cero");
            }

            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == account.AccountNumber);
            if (existingAccount != null)
            {
                return BadRequest($"La Cuenta {account.AccountNumber} ya Existe");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Realizar operaciones adicionales según el tipo de cuenta
            if (account.AccountType == 'A')
            {
                // Cuenta de Ahorros
                // El Valor del Balance es igual al valor inicial de la apertura
                account.BalanceAmount = account.BalanceAmount;
            }
            else if (account.AccountType == 'C')
            {
                // Cuenta Corriente
                // El valor del Balance inicial es igual al Valor Ingresado más el Valor Maximo de sobregiro
                account.BalanceAmount = account.BalanceAmount + MAX_OVERDRAFT;
            }

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (!AccountExists(id))
            {
                return BadRequest($"La Cuenta {id} No Existe");
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