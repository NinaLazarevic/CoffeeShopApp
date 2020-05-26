using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopApp.Data.Models
{
    public class EmployeeModel : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JMBG { get; set; }

        public DateTime DateofBirth { get; set; }

        public Nullable<DateTime> DateDeleted{ get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}
