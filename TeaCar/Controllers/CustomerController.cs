using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaCar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeaCar.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ISAD251_STurnerContext _context;

        public CustomerController(ISAD251_STurnerContext context)
            //Constructor with database class.
        {
            _context = context;
            //Dependency injection.
        }
        public IActionResult Index()
        {
            IEnumerable<SelectListItem> DrinksList = (from eachItem in _context.Items.AsEnumerable()
                                                      select new SelectListItem
                                                      {
                                                          Text = eachItem.ItemName,
                                                          Value = eachItem.ItemId.ToString()
                                                      }).ToList();
            //Linq
            ViewBag.Drinks = DrinksList;
            return View();
        }
        public IActionResult OrderFinalisation()
        {
            return View();
        }
    }
}