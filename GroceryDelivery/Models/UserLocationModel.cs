using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.Models
{
    public class UserLocationModel
    {
        public string Adress { get; set; }
        public long longtitude { get; set; }
        public long latitude { get; set; }
    }
}