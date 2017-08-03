using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFTechnologies.Models;

namespace TFTechnologies.Controllers
{
    public class TicketsTypesController : Controller
    {
        private readonly T3FWebContext _context;

        public TicketsTypesController(T3FWebContext context)
        {
            _context = context;    
        }

        // GET: TicketsTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketsType.ToListAsync());
        }

        // GET: TicketsTypes/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketsType = await _context.TicketsType
                .SingleOrDefaultAsync(m => m.TypeId == id);
            if (ticketsType == null)
            {
                return NotFound();
            }

            return View(ticketsType);
        }

        // GET: TicketsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeTitle,Description")] TicketsType ticketsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketsType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticketsType);
        }

        // GET: TicketsTypes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketsType = await _context.TicketsType.SingleOrDefaultAsync(m => m.TypeId == id);
            if (ticketsType == null)
            {
                return NotFound();
            }
            return View(ticketsType);
        }

        // POST: TicketsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("TypeId,TypeTitle,Description")] TicketsType ticketsType)
        {
            if (id != ticketsType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketsTypeExists(ticketsType.TypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ticketsType);
        }

        // GET: TicketsTypes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketsType = await _context.TicketsType
                .SingleOrDefaultAsync(m => m.TypeId == id);
            if (ticketsType == null)
            {
                return NotFound();
            }

            return View(ticketsType);
        }

        // POST: TicketsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var ticketsType = await _context.TicketsType.SingleOrDefaultAsync(m => m.TypeId == id);
            _context.TicketsType.Remove(ticketsType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketsTypeExists(short id)
        {
            return _context.TicketsType.Any(e => e.TypeId == id);
        }
    }
}
