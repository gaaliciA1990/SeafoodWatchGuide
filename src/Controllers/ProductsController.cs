using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /*
         * This is a constructor for the controller 
         */
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /*
         * This is a getter method for ProductService
         */
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        /*
         * This is retrieving the product information from the JSON file
         */
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpPatch]
        /*
         *  This code gets the rating from the user, sets the rating in the variable,
         *  then appends the rating to the JSON file
         */
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /*
         * This is the model for the ratings. Represents the data to be updated
         * in the JSON file
         */

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}