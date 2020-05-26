using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeShopApp.Data.Models
{
    public class OrderModel
    {
        [Key]
        public Guid OrderId { get; set; }

        public int OrderNumber { get; set; }

        public EmployeeModel Employee { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime DateofOrder { get; set; }

        public Nullable<DateTime> DateDeleted { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
    }

    public class OrderedProducts
    {
        public Guid OrderId { get; set; }

        public OrderModel Order { get; set; }

        public Guid ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}
