using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCD0704.AppDev.Models;
using System.Data.Entity;

namespace GCD0704.AppDev.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Profiles()
        {
            var users = _context.Users
                .Include(u => u.Roles)
                .ToList();
            return View(users);
        }
    }
}