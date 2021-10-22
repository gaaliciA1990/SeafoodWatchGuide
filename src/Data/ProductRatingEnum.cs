using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Data
{

    public enum Product_Rating
    {
        [EnumMember(Value = "3")] BEST_CHOICE,
        [EnumMember(Value = "2")] GOOD_ALTERNATIVE,
        [EnumMember(Value = "1")] AVOID
    }
}
