using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFTechnologies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TFTechnologies.Controllers
{
    public class HomeController : Controller
    {
        private T3FWebContext _context;

        public HomeController(T3FWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Media()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Contact()
        {
            
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccounts user)
        {
            if (ModelState.IsValid)
            {
                _context.UserAccounts.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " is successfully registered.";

            }

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.txtMessage = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccounts user)
        {
            var account = _context.UserAccounts.Where(u => u.Email == user.Email && u.Password == user.Password)
                .SingleOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.UserId.ToString());
                HttpContext.Session.SetString("Email", account.Email);
                //HttpContext.Session.SetString("UserName", account.Username);
                return RedirectToAction("Index", "Feedbacks");
            }
            else
            {
                ModelState.AddModelError("", " username or password is wrong.");
            }

            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("UserName");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }

}
