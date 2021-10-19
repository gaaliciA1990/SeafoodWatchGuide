using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace ContosoCrafts.WebSite.Pages
{
    public class CreateModel : PageModel
    {
        // ILogger variable
        private readonly ILogger<IndexModel> _logger;
        /*
         * Constructor method for the Create Page
         */
        public CreateModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        [BindProperty]

        /*
         * Getter and Setter method for the Creat page
         */
        public ProductModel Product { get; set; }

        /*
         * Allow an error message to be displayed if the error not null
         */
        public string error = null;

        /*
         * Since we are creating a new record in the dataset, we don't need to pull anything for validation
         */
        public void OnGet()
        {
        }

        /*
         * Upon clicking Create, the update is saved and the user is redirected back to the Admin page to 
         * so they can update more information
         */
        public IActionResult OnPost()
        {
            ProductService.CreateCard(Product);
            return Redirect("Admin");
        }
    }
}
