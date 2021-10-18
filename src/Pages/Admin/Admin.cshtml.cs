using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Template for page creation
    /// </summary>
    public class AdminModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public AdminModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<ProductModel> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
        /*
         * 
         */
        public IActionResult OnGetCreate()
        {
            return RedirectToPage("Admin/Create");
        }

        public IActionResult OnGetDelete(string Id)
        {
            ProductService.DeleteCard(Id);
            return RedirectToPage("Admin");
        }

        public IActionResult OnGetUpdate(string Id)
        {
            return RedirectToPage("Admin/Update", new { id = Id });
        }

        public IActionResult OnGetRead(string Id)
        {
            return RedirectToPage("Read", new { id = Id });
        }
    }
}