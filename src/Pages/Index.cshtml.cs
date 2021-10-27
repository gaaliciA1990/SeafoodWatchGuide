using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Home page for Seafood Watch Guide from GladiatorMonkys 
    /// group in Fundamentals of Software Engineering, CPSC 5110
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor for Index page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<ProductModel> Products { get; private set; }


        /// <summary>
        /// Method to fetch all items to be shown on the Index page
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}