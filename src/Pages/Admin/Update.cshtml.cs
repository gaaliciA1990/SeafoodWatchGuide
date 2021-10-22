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
    public class UpdateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public UpdateModel(ILogger<IndexModel> logger, JsonFileProductService productService)
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
            if (id is null)
            {
                error = "id not selected";
                return;
            }
            Product = ProductService.GetDataItem(id);
            if (Product is null)
                error = "id not found";

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateCard(Product);
            // Redirect back to the admin page to continue editing if needed
            return Redirect("Admin");
        }
    }
}