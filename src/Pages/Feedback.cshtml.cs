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
    public class FeedbackPageModel : PageModel
    {
        //Logger to help with debugging
        private readonly ILogger<FeedbackPageModel> _logger;

        //To get connected to all provided services
        public JsonFileFeedbackService FeedbackService { get; }

        //To store all products currently in database
        public IEnumerable<FeedbackModel> Feedback { get; private set; }

        /// <summary>
        /// Constructor for Index page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public FeedbackPageModel(ILogger<FeedbackPageModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to fetch all items to be shown on the Index page
        /// </summary>
        public void OnGet()
        {
        }
    }
}