using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Custom data annotation, check string length in List
    /// </summary>
    public class ListStringLength : ValidationAttribute
    {
        //max character allowed in Kist item
        public int MinStringLength { get; set; }
        //min character allowed in Kist item
        public int MaxStringLength { get; set; }
        /// <summary>
        /// validate list items in value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            foreach (var str in value as List<string>)
            {
                if (str.Length > MaxStringLength || str.Length < MinStringLength) 
                { 
                    return false;
                }
            }
            return true;
        }
    }
}
