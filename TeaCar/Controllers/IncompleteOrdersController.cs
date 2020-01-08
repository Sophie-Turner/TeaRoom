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
    public class IncompleteOrdersController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public IncompleteOrdersController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SubmitOrder(UpdateTableNum updateTableNum)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC UpdateTableNum @tableNum",
                new SqlParameter("@tableNum", updateTableNum.tableNum));
            ViewBag.submittedOrder = rowsAffected;
            return RedirectToAction(nameof(TeaCar.Controllers.CustomerMenusController.Index));
        }

        // GET: IncompleteOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncompleteOrders.ToListAsync());
        }

        // GET: IncompleteOrders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incompleteOrders = await _context.IncompleteOrders
                .FirstOrDefaultAsync(m => m.itemName == id);
            if (incompleteOrders == null)
            {
                return NotFound();
            }

            return View(incompleteOrders);
        }

        // GET: IncompleteOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncompleteOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("itemName,quantity,itemPrice")] IncompleteOrders incompleteOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incompleteOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incompleteOrders);
        }

        // GET: IncompleteOrders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incompleteOrders = await _context.IncompleteOrders.FindAsync(id);
            if (incompleteOrders == null)
            {
                return NotFound();
            }
            return View(incompleteOrders);
        }

        // POST: IncompleteOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("itemName,quantity,itemPrice")] IncompleteOrders incompleteOrders)
        {
            if (id != incompleteOrders.itemName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incompleteOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncompleteOrdersExists(incompleteOrders.itemName))
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
            return View(incompleteOrders);
        }

        // GET: IncompleteOrders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incompleteOrders = await _context.IncompleteOrders
                .FirstOrDefaultAsync(m => m.itemName == id);
            if (incompleteOrders == null)
            {
                return NotFound();
            }

            return View(incompleteOrders);
        }

        // POST: IncompleteOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var incompleteOrders = await _context.IncompleteOrders.FindAsync(id);
            _context.IncompleteOrders.Remove(incompleteOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncompleteOrdersExists(string id)
        {
            return _context.IncompleteOrders.Any(e => e.itemName == id);
        }
    }
}
