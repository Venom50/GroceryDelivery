using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.ViewModels
{
    public class MapViewModel
    {

        public UserLocationModel UserLocation { get; set; }
        public List<ShopModel> Shops { get; set; }
    }
}