using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
   public class JsonFileProductService
    {
        /*
         * Constructor method for the web host environment
         */
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /*
         * A getter method for the webhost
         */
        public IWebHostEnvironment WebHostEnvironment { get; }

        /*
         * This simplified the file path for the JSON file so it can be inferred instead
         * of being hardcoded. Makes tracking data easier
         */
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Seafoods.json"); }
        }

        /*
         * This is creating a list of product Models.
         * IEnumerable is a list type
         */
        public IEnumerable<ProductModel> GetAllData()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }


    }
}