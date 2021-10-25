using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILogger<ReadModel> _logger;

        public ReadModel(ILogger<ReadModel> logger, JsonFileProductService productService)
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
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
        
        public IActionResult OnGetDelete(string Id)
        {
            return RedirectToPage("Delete", new { id = Id });
        }

        public IActionResult OnGetUpdate(string Id)
        {
            return RedirectToPage("Update", new { id = Id });
        }
        
    }
}