using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This is the ENUM class for seafood ratings, which are displayed on each card and dictate
/// which section of the guide the fish card is displayed on.
/// </summary>
namespace ContosoCrafts.WebSite.Data
{
    public enum ProductRating
    {
        // EnumMember value is intened to convert the numerical ratings
        // in the JSON file to their respective ENUM. Still not working, bug logged
        [EnumMember(Value = "3")] BEST_CHOICE,
        [EnumMember(Value = "2")] GOOD_ALTERNATIVE,
        [EnumMember(Value = "1")] AVOID

    }
}
