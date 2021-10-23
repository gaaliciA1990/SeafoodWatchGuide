using System.ComponentModel.DataAnnotations;
using System;
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

        [Required(ErrorMessage = "Please choose a region")]
        public string Region { get; set; }


        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Please give a valid url link")]
        [DataType(DataType.Url)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "Please choose a rating")]
        public Product_Rating Rating { get; set; }


        /// <summary>
        /// The is a toString method that will convert this class (the model) to a string version. 
        /// This is using the JSON mechanism for serializing the model data to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}