using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Template for index (ie.Admin) page creation
    /// </summary>
    public class AdminModel : PageModel
    {
        //Logger
        private readonly ILogger<AdminModel> _logger;

        /// <summary>
        /// Constructor method for Admin Page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public AdminModel(ILogger<AdminModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Declares a getter for ProductService
        /// </summary>
        /// <returns></returns>
        public JsonFileProductService ProductService 
        { 
            get; 
        }

        /// <summary>
        /// Declares a public getter and a private setter for Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> Products 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// Initializing method for Admin page. All products are shown.
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }

        /// <summary>
        /// Method to react to an action of clicking on the Create button
        /// on the Admin page. User gets redirected to Create page.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGetCreate()
        {
            return RedirectToPage("Create");
        }
    }
}