using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// The region page will display only the data of the region that is selected from the homepage.
    /// This removes the need for more than one guide page as we can pass the region string
    /// to display the data on that page.
    /// </summary>
    public class RegionModel : PageModel
    {
        private readonly ILogger<RegionModel> _logger;

        public RegionModel(ILogger<RegionModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
        }

        public string region;

        /// <summary>
        /// OnGet will retrieve the data from the Seafoods.json file 
        /// and return only the seafood from the region passed
        /// </summary>
        /// <param name="region"></param>
        public void OnGet(string region)
        {
            this.region = region;
        }
    }
}