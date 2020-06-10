using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.ViewModels
{
    public class OrderViewModel
    {
        public ShopModel shop { get; set; }

        public List<ProductModel> products { get; set; }

    }
}