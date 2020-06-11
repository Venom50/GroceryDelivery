using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.ViewModels
{
    public class OrderPriceViewModel
    {
        public List<ProductModel> products { get; set; }
        public List<double?> priceOrder { get; set; }
    }
}