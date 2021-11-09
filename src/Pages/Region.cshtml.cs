using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// The region page will display only the data of the region that is selected from the homepage.
    /// This removes the need for more than one guide page as we can pass the region string
    /// to display the data on that page.
    /// </summary>
    public class RegionModel : PageModel
    {
        //Logger to help with debugging
        private readonly ILogger<RegionModel> _logger;


        /// <summary>
        /// Constructor for Region page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public RegionModel(ILogger<RegionModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
        }

        //Variable to store the ID of the region being requested
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