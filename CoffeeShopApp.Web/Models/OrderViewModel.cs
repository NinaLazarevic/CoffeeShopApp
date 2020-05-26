using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApp.Web.Models
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }

        public int OrderNumber { get; set; }

        public DateTime DateofOrder { get; set; }

        public Nullable<DateTime> DateDeleted { get; set; }

        [Required]
        public List<Guid> Products { get; set; }

        public float TotalPrice { get; set; }

        public string EmployeeUserName { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
