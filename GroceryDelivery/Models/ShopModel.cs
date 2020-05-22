using GroceryDelivery.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryDelivery.Models
{
    public class ShopModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage = "Nazwa sklepu może wynosić więcej niż 50 znaków")]
        public string Name { get; set; }

        [Required]
        public float latidute { get; set; }

        [Required]
        public float longtitude { get; set; }

        [Required]
        public EShopType ShopType { get; set; }
    }
}