﻿using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.SQL
{
    public interface IShopRepository
    {
        IEnumerable<ShopModel> GetAllShops();
    }
}