using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaCar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace TeaCar.Controllers
{
    public class StaffController : Controller
    {
        private readonly ISAD251_STurnerContext _context;
        public StaffController(ISAD251_STurnerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(CreateNewItem createNewItem)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC CreateItem @itemName, @itemInfo, @itemPicFile, @onSale, @itemPrice, @catId",
                new SqlParameter("@itemName", createNewItem.itemName.ToString()),
                new SqlParameter("@itemInfo", createNewItem.itemInfo.ToString()),
                new SqlParameter("@itemPicFile", createNewItem.itemPicFile.ToString()),
                new SqlParameter("@onSale", createNewItem.onSale),
                new SqlParameter("@itemName", createNewItem.itemPrice),
                new SqlParameter("@itemName", createNewItem.catId));

            ViewBag.NewItem = rowsAffected;
            return View("Index"); //Go back to the staff home page.
        }
    }
}