using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json;
using ContosoCrafts.WebSite.Data;



namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Code version respenting the elements of the JSON file.
    /// </summary>
    public class FilterModel
    {
        public string Region;

        public ProductRating Rating;

    }
}