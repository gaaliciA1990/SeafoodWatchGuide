using System;
using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Template for page creation
    /// </summary>
    public class ReadModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ReadModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public ProductModel Product { get; set; }

        public string error = null;
        public string myID = null;

        public void OnGet(string id)
        {
            if (id is null)
            {
                error = "id not selected";
                return;
            }
            Product = ProductService.GetDataItem(id);

            if (Product is null)
                error = "id not found";
        }
        /*
         * 
         */

        public IActionResult OnGetDelete(string Id)
        {
            ProductService.DeleteCard(Id);
            return RedirectToPage("Admin");
        }

        public IActionResult OnGetUpdate()
        {
            return RedirectToPage("Admin/Update", new { id = Product.Id });
        }
    }
}