using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Net.Http;
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

        public IEnumerable<ProductModel> GetRegionData(string region)
        {
            var data = GetAllData();
            var test = from d in data
                       where d.Region == region
                       select d;
            return test;
        }

        public ProductModel? GetDataItem(string id)
        {
            var data = GetAllData();
            var test = from d in data
                       where d.Id == id
                       select d;

            return (test.Count() > 0)? test.First(): null;
        }

        public void UpdateCard(ProductModel model)
        {
            var products = GetAllData();
            // LINQ
            var query = products.First(x => (x.Id == model.Id && x.Region == model.Region));
            query.Image = model.Image;
            query.Rating = model.Rating;
            query.Title = model.Title;
            query.Description = model.Description;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(products, options);

            File.WriteAllText(JsonFileName, jsonString);
        }

        public void DeleteCard(string Id)
        {

            var products = GetAllData();
            // LINQ
            var query = products.Where(x => (x.Id != Id));

            System.Diagnostics.Debug.WriteLine(query.Count());


            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(query, options);

            File.WriteAllText(JsonFileName, jsonString);
        }

    }

}