using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Page place holder for base code from index page
    /// </summary>
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
            /// ProductService = productService;
        }

        public void OnGet()
        {
        }
    }
}