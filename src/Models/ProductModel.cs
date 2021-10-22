using System.Text.Json;
using System.Text.Json.Serialization;
using ContosoCrafts.WebSite.Data;



namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Code version respenting the elements of the JSON file.
    /// </summary>
    public class ProductModel
    {
        public string Id { get; set; }
        public string Region { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Product_Rating Rating { get; set; }

        /// <summary>
        /// Place holder for all Regions currently supported (will change once we
        /// get our json files for each region up and running
        /// </summary>
        public static string[] Regions
        {
            get { return (string[])Regions.Clone(); }
            set
            {
                Regions = new string[7]{"West Coast", "Southwest", "Central", "Southeast",
                                "Northeast", "Hawai'i", "National"};
            }
        }

        /// <summary>
        /// The is a toString method that will convert this class (the model) to a string version. 
        /// This is using the JSON mechanism for serializing the model data to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}