using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeaCar.Models;
using Microsoft.Data.SqlClient;

namespace TeaCar.Controllers
{
    public class CustomerMenusController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public CustomerMenusController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        public IActionResult Clear(CancelIncompleteOrder cancelIncompleteOrder)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC CancelIncompleteOrder");
            ViewBag.DeletedIncompleteOrder = rowsAffected;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddItemToOrder(AddToOrder addToOrder)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC AddToOrder @itemId",
                new SqlParameter("@itemId", addToOrder.itemId));
            ViewBag.NewItemOrder = rowsAffected;
            return RedirectToAction(nameof(Index));
        }
        

        // GET: CustomerMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerMenu.ToListAsync());
        }

        // GET: CustomerMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerMenu = await _context.CustomerMenu
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (customerMenu == null)
            {
                return NotFound();
            }

            return View(customerMenu);
        }

        // GET: CustomerMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("itemId,itemName,itemInfo,itemPrice,catId")] CustomerMenu customerMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerMenu);
        }

        // GET: CustomerMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerMenu = await _context.CustomerMenu.FindAsync(id);
            if (customerMenu == null)
            {
                return NotFound();
            }
            return View(customerMenu);
        }

        // POST: CustomerMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("itemId,itemName,itemInfo,itemPrice,catId")] CustomerMenu customerMenu)
        {
            if (id != customerMenu.itemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerMenuExists(customerMenu.itemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerMenu);
        }

        // GET: CustomerMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerMenu = await _context.CustomerMenu
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (customerMenu == null)
            {
                return NotFound();
            }

            return View(customerMenu);
        }

        // POST: CustomerMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerMenu = await _context.CustomerMenu.FindAsync(id);
            _context.CustomerMenu.Remove(customerMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerMenuExists(int id)
        {
            return _context.CustomerMenu.Any(e => e.itemId == id);
        }
    }
}
