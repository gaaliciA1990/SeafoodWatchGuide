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
        //Keep track of the unique ID of the product
        public string Id { get; set; }


        //Keep track of which region the product belongs to
        [Required(ErrorMessage = "Please choose a region")]
        public string Region { get; set; }


        //Keep track of the image that represents the product
        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Please give a valid url link")]
        [DataType(DataType.Url)]
        public string Image { get; set; }


        //Contains the name of the product
        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; }


        //Contains the description of the product
        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }


        //Contains the rating of the product, should be 1 of the specified enums
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "Please choose a rating")]
        public ProductRating Rating { get; set; }

        /// <summary>
        /// This will convert the ENUM values to a String format so it's easier for 
        /// users to read and not in variable format
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static string convertToString(ProductRating rating)
        {
            string str = Enum.GetName(rating);
            str = str.Replace("_", " ");
            str = char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str;
        }

        /// <summary>
        /// The is a toString method that will convert this class (the model) to a string version. 
        /// This is using the JSON mechanism for serializing the model data to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}