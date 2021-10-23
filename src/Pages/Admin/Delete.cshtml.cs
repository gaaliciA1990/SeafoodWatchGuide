using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Template for page creation
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public DeleteModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        [BindProperty]
        public ProductModel Product { get; set; }

        public string error = null;

        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        public IActionResult OnPost()
        {
            //delete card
            ProductService.DeleteCard(Product.Id);
            // Redirect back to the admin page to continue editing if needed
            return Redirect("Admin");
        }



    }
}