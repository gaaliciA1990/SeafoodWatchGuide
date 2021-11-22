using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// This class is the controller for handling interactions with our products
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        /// <summary>
        /// This is a constructor for the controller 
        /// </summary>
        /// <param name="feedbackService"></param>
        public FeedbackController(JsonFileFeedbackService feedbackService)
        {
            FeedbackService = feedbackService;
        }

        // This is a getter method for ProductService
        public JsonFileFeedbackService FeedbackService { get; }

        /// <summary>
        /// This is retrieving the product information from the JSON file
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FeedbackModel> Get()
        {
            return FeedbackService.GetAllFeedback();
        }

        [HttpPatch]
        /// <summary>
        /// This code gets the rating from the user, sets the rating in the variable,
        /// then appends the rating to the JSON file
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult Patch([FromBody] FeedbackRequest request)
        {
            FeedbackService.CreateFeedback(request.Rating, request.Comment);
            return Ok();
        }

        /// <summary>
        /// This is the model for the feedback. Represents the data to be updated
        /// in the JSON file. Will associate a rating with a seafood product
        /// </summary>
        public class FeedbackRequest
        {
            public string ID { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; }
        }
    }
}