using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaCar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        public IActionResult EditProduct()
        {

            
            //Linq
            ViewBag.Items = ComboAllItems();
            return View();
        }
        public IActionResult NewProduct()
        {
            return View();
        }

        public IEnumerable<SelectListItem> ComboAllItems()
        {
            IEnumerable<SelectListItem> ItemList = (from eachItem in _context.Items.AsEnumerable()
                                                    select new SelectListItem
                                                    {
                                                        Text = eachItem.ItemName,
                                                        Value = eachItem.ItemId.ToString()
                                                    }).ToList();
            return ItemList;
        }


        [HttpPost]
        public IActionResult CreateItem(CreateNewItem createNewItem)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC CreateNewItem @itemName, @itemInfo, @onSale, @itemPrice, @catId",
                new SqlParameter("@itemName", createNewItem.itemName.ToString()),
                new SqlParameter("@itemInfo", createNewItem.itemInfo.ToString()),
                new SqlParameter("@onSale", createNewItem.onSale),
                new SqlParameter("@itemPrice", createNewItem.itemPrice),
                new SqlParameter("@catId", createNewItem.catId));

            ViewBag.NewItem = rowsAffected;
            return View("NewProduct"); //Stay on the same page.
        }

        [HttpPost]

        public IActionResult EditItem(UpdateItem updateItem)
        {
            
            var rowsAffected = _context.Database.ExecuteSqlRaw(
            //Insert/update only returns integer, not other data.
                "EXEC UpdateItem @itemId, @newItemName, @newItemInfo, @newOnSale, @newItemPrice, @newCatId",
                new SqlParameter("@itemId", updateItem.itemId),
                new SqlParameter("@newItemName", updateItem.newItemName.ToString()),
                new SqlParameter("@newItemInfo", updateItem.newItemInfo.ToString()),
                new SqlParameter("@newOnSale", updateItem.newOnSale),
                new SqlParameter("@newItemPrice", updateItem.newItemPrice),
                new SqlParameter("@newCatId", updateItem.newCatId));

            ViewBag.UpdateItem = rowsAffected;
            return View("EditProduct");
        }
    }
}