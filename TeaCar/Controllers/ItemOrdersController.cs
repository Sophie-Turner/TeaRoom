using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeaCar.Models;

namespace TeaCar.Controllers
{
    public class ItemOrdersController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public ItemOrdersController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        // GET: ItemOrders
        public async Task<IActionResult> Index()
        {
            var iSAD251_STurnerContext = _context.ItemOrders.Include(i => i.Item).Include(i => i.Order);
            return View(await iSAD251_STurnerContext.ToListAsync());
        }

        // GET: ItemOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrders = await _context.ItemOrders
                .Include(i => i.Item)
                .Include(i => i.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (itemOrders == null)
            {
                return NotFound();
            }

            return View(itemOrders);
        }

        // GET: ItemOrders/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: ItemOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ItemId,Quantity")] ItemOrders itemOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", itemOrders.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", itemOrders.OrderId);
            return View(itemOrders);
        }

        // GET: ItemOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrders = await _context.ItemOrders.FindAsync(id);
            if (itemOrders == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", itemOrders.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", itemOrders.OrderId);
            return View(itemOrders);
        }

        // POST: ItemOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ItemId,Quantity")] ItemOrders itemOrders)
        {
            if (id != itemOrders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemOrdersExists(itemOrders.OrderId))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", itemOrders.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", itemOrders.OrderId);
            return View(itemOrders);
        }

        // GET: ItemOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrders = await _context.ItemOrders
                .Include(i => i.Item)
                .Include(i => i.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (itemOrders == null)
            {
                return NotFound();
            }

            return View(itemOrders);
        }

        // POST: ItemOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemOrders = await _context.ItemOrders.FindAsync(id);
            _context.ItemOrders.Remove(itemOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemOrdersExists(int id)
        {
            return _context.ItemOrders.Any(e => e.OrderId == id);
        }
    }
}
