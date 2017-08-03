using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFTechnologies.Models;
using Microsoft.AspNetCore.Http;

namespace TFTechnologies.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly T3FWebContext _context;

        public FeedbacksController(T3FWebContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.txtMessage = "Feedbacks";
                return View(await _context.TicketsType.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> CreateTasks(long? id)
        {
            if (HttpContext.Session.GetString("UserID") is null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
            }
            var ticketsType = await _context.TicketsType.SingleOrDefaultAsync(m => m.TypeId == id);
            var userType = await _context.UserAccounts.SingleOrDefaultAsync(m => m.UserId == Int32.Parse(HttpContext.Session.GetString("UserID")));
            if (ticketsType == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["ReplyId"] = new SelectList(_context.Tickets, "TicketId", "Priority");
            ViewData["TypeId"] = new SelectList(_context.TicketsType, "TypeId", "TypeTitle", ticketsType.TypeId);
            ViewData["UserId"] = new SelectList(_context.WebUser, "UserId", "FirstName", userType.UserId );
            return View();
            
        }
    }
}
