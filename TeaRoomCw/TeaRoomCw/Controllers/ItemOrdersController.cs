using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeaRoomCw.Models;

namespace TeaRoomCw.Controllers
{
    public class ItemOrdersController : Controller
    {
        private readonly TheContext _context;

        public ItemOrdersController(TheContext context)
        {
            _context = context;
        }

        // GET: ItemOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemOrders.ToListAsync());
        }

        // GET: ItemOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrder = await _context.ItemOrders
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (itemOrder == null)
            {
                return NotFound();
            }

            return View(itemOrder);
        }

        // GET: ItemOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderId,itemId,quantity")] ItemOrder itemOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemOrder);
        }

        // GET: ItemOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrder = await _context.ItemOrders.FindAsync(id);
            if (itemOrder == null)
            {
                return NotFound();
            }
            return View(itemOrder);
        }

        // POST: ItemOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderId,itemId,quantity")] ItemOrder itemOrder)
        {
            if (id != itemOrder.orderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemOrderExists(itemOrder.orderId))
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
            return View(itemOrder);
        }

        // GET: ItemOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemOrder = await _context.ItemOrders
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (itemOrder == null)
            {
                return NotFound();
            }

            return View(itemOrder);
        }

        // POST: ItemOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemOrder = await _context.ItemOrders.FindAsync(id);
            _context.ItemOrders.Remove(itemOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemOrderExists(int id)
        {
            return _context.ItemOrders.Any(e => e.orderId == id);
        }
    }
}
