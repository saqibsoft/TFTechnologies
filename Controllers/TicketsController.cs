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
    public class TicketsController : Controller
    {
        private readonly T3FWebContext _context;

        public TicketsController(T3FWebContext context)
        {
            _context = context;    
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var t3FWebContext = _context.Tickets.Include(t => t.Product).Include(t => t.Reply).Include(t => t.Type).Include(t => t.User);
            return View(await t3FWebContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Reply)
                .Include(t => t.Type)
                .Include(t => t.User)
                .SingleOrDefaultAsync(m => m.TicketId == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Tasks()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["ReplyId"] = new SelectList(_context.Tickets, "TicketId", "Priority");
            ViewData["TypeId"] = new SelectList(_context.TicketsType, "TypeId", "TypeTitle");
            ViewData["UserId"] = new SelectList(_context.WebUser, "UserId", "Password");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,TypeId,UserId,Subject,Priority,MsgDetail,EntryDate,Status,ReplyId,ProductId")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", tickets.ProductId);
            ViewData["ReplyId"] = new SelectList(_context.Tickets, "TicketId", "Priority", tickets.ReplyId);
            ViewData["TypeId"] = new SelectList(_context.TicketsType, "TypeId", "TypeId", tickets.TypeId);
            ViewData["UserId"] = new SelectList(_context.WebUser, "UserId", "Password", tickets.UserId);
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketId == id);
            if (tickets == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", tickets.ProductId);
            ViewData["ReplyId"] = new SelectList(_context.Tickets, "TicketId", "Priority", tickets.ReplyId);
            ViewData["TypeId"] = new SelectList(_context.TicketsType, "TypeId", "TypeId", tickets.TypeId);
            ViewData["UserId"] = new SelectList(_context.WebUser, "UserId", "Password", tickets.UserId);
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TicketId,TypeId,UserId,Subject,Priority,MsgDetail,EntryDate,Status,ReplyId,ProductId")] Tickets tickets)
        {
            if (id != tickets.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketsExists(tickets.TicketId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", tickets.ProductId);
            ViewData["ReplyId"] = new SelectList(_context.Tickets, "TicketId", "Priority", tickets.ReplyId);
            ViewData["TypeId"] = new SelectList(_context.TicketsType, "TypeId", "TypeId", tickets.TypeId);
            ViewData["UserId"] = new SelectList(_context.WebUser, "UserId", "Password", tickets.UserId);
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Reply)
                .Include(t => t.Type)
                .Include(t => t.User)
                .SingleOrDefaultAsync(m => m.TicketId == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tickets = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketId == id);
            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketsExists(long id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
