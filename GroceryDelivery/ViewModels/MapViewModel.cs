using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.ViewModels
{
    public class MapViewModel:UserLocationModel
    {
        public List<ShopModel> Shops { get; set; }
    }
}