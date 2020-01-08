using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeaCar.Models;
using Microsoft.EntityFrameworkCore;

namespace TeaCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public HomeController(ISAD251_STurnerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Database.ExecuteSqlRaw("EXEC CancelIncompleteOrder");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
