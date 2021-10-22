using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /*
     * Code version respenting the elements of the JSON file. 
     */
    public class ProductModel
    {
        public string Id { get; set; }
        public string Region { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        //Place holder for all Regions currently supported (will change once we
        //get our json files for each region up and running
        public string[] Regions
        {
            get { return (string[]) Regions.Clone(); }
            set
            {
                Regions = new string[7]{"West Coast", "Southwest", "Central", "Southeast",
                                "Northeast", "Hawai'i", "National"};
            }
        }
        /*
         * The is a toString method that will convert this class (the model) to a string version.
         * This is using the JSON mechanism for serializing the model data to a string
         */
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this); 
    }
}