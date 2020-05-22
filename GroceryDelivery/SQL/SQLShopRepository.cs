using GroceryDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryDelivery.SQL
{
    public class SQLShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext Context;
        public SQLShopRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<ShopModel> GetAllShops()
        {
            return Context.ShopModels;
        }
    }
}