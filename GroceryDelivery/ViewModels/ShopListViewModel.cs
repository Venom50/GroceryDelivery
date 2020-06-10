using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.ViewModels
{
    public class ShopListViewModel
    {
        public IEnumerable<ShopModel> shopList { get; set; }
    }
}