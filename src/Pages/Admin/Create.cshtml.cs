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
        private readonly ILogger<CreateModel> _logger;

        /// <summary>
        /// Constructor method for the Create Page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(ILogger<CreateModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Getter and Setter method for the Creat page
        /// </summary>
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Allow an error message to be displayed if the error not null
        /// </summary>
        public string error = null;

        /// <summary>
        /// Since we are creating a new record in the dataset, we don't need to pull anything for validation
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Upon clicking Submit, the update is saved and the user is redirected back to the Admin page to 
        /// so they can update more information
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //Check for input validation, if not valid, return to page
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //If valid, create the card
            ProductService.CreateCard(Product);
            return RedirectToPage("Admin");
        }
    }
}
