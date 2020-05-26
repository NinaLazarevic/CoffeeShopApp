using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeShopApp.Data.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        public Nullable<DateTime> DateDeleted { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
