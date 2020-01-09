using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaCar.Models;

namespace TeaCar.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ISAD251_STurnerContext _context;

        public MenuController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMenu>>> GetCustomerMenu()
        {
            return await _context.CustomerMenu.ToListAsync();
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMenu>> GetCustomerMenu(int id)
        {
            var customerMenu = await _context.CustomerMenu.FindAsync(id);

            if (customerMenu == null)
            {
                return NotFound();
            }

            return customerMenu;
        }

        // PUT: api/Menu/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMenu(int id, CustomerMenu customerMenu)
        {
            if (id != customerMenu.itemId)
            {
                return BadRequest();
            }

            _context.Entry(customerMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMenuExists(id))
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

        // POST: api/Menu
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustomerMenu>> PostCustomerMenu(CustomerMenu customerMenu)
        {
            _context.CustomerMenu.Add(customerMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerMenu", new { id = customerMenu.itemId }, customerMenu);
        }

        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerMenu>> DeleteCustomerMenu(int id)
        {
            var customerMenu = await _context.CustomerMenu.FindAsync(id);
            if (customerMenu == null)
            {
                return NotFound();
            }

            _context.CustomerMenu.Remove(customerMenu);
            await _context.SaveChangesAsync();

            return customerMenu;
        }

        private bool CustomerMenuExists(int id)
        {
            return _context.CustomerMenu.Any(e => e.itemId == id);
        }
    }
}
