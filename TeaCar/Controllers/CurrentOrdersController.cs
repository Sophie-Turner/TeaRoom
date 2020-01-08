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
    public class CurrentOrdersController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public CurrentOrdersController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        public IActionResult CancelOrder(CancelCompleteOrder cancelCompleteOrder)
        {
            _context.Database.ExecuteSqlRaw("EXEC CancelCompleteOrder @orderTime",
                new SqlParameter("@orderTime", cancelCompleteOrder.orderTime));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CompletedOrder(UpdateCompleted updateCompleted)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateCompleted @orderTime",
                new SqlParameter("@orderTime", updateCompleted.orderTime));
            return RedirectToAction(nameof(Index));
        }

        // GET: CurrentOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurrentOrders.ToListAsync());
        }

        // GET: CurrentOrders/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentOrders = await _context.CurrentOrders
                .FirstOrDefaultAsync(m => m.OrderTime == id);
            if (currentOrders == null)
            {
                return NotFound();
            }

            return View(currentOrders);
        }

        // GET: CurrentOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurrentOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderTime,tableNum,itemName,quantity")] CurrentOrders currentOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentOrders);
        }

        // GET: CurrentOrders/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentOrders = await _context.CurrentOrders.FindAsync(id);
            if (currentOrders == null)
            {
                return NotFound();
            }
            return View(currentOrders);
        }

        // POST: CurrentOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("OrderTime,tableNum,itemName,quantity")] CurrentOrders currentOrders)
        {
            if (id != currentOrders.OrderTime)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentOrdersExists(currentOrders.OrderTime))
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
            return View(currentOrders);
        }

        // GET: CurrentOrders/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentOrders = await _context.CurrentOrders
                .FirstOrDefaultAsync(m => m.OrderTime == id);
            if (currentOrders == null)
            {
                return NotFound();
            }

            return View(currentOrders);
        }

        // POST: CurrentOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var currentOrders = await _context.CurrentOrders.FindAsync(id);
            _context.CurrentOrders.Remove(currentOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentOrdersExists(DateTime id)
        {
            return _context.CurrentOrders.Any(e => e.OrderTime == id);
        }
    }
}
