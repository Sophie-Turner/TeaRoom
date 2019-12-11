using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaRoomCw.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeaRoomCw.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TheContext theContext;

        public CustomerController(TheContext context)
        {
            theContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<> menuItems = (from eachItem in theContext.Items.AsEnumerable()
                                                     select new SelectListItem
                                                     {
                                                         Text = eachItem.itemName,
                                                         Value = eachItem.itemId.ToString()
                                                     }).ToList();

            ViewBag.Items = menuItems;
            return View();
        }

       
    }
}