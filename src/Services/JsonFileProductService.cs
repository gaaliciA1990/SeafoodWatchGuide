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
        /*
         * This method will pull all of the Seafood products and appeand the data entered in the form
         * to the JSON file and serialize the data
         */
        public void CreateCard(ProductModel model)
        {
            var products = GetAllData();

            products = products.Append(model);

            SaveData(products);
        }

        /// <summary>
        /// Update the item from the System
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductModel UpdateCard(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            productData.Title = data.Title;
            productData.Description = data.Description;
            productData.Image = data.Image;
            productData.Rating = data.Rating;
            productData.Region = data.Region;

            SaveData(products);

            return productData;
        }

        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
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