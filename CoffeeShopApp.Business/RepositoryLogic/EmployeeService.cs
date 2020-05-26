using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShopApp.Data;
using CoffeeShopApp.Data.Models;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public class EmployeeService : IEmployeeService
    {
        private CoffeeShopDbContext dbContext;

        public EmployeeService(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<EmployeeModel> Employees => dbContext.Users;

        public void DeleteEmployee(Guid employeeId)
        {
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id.Equals(employeeId));

            if (employeeToDelete == null) return;

            employeeToDelete.DateDeleted = DateTime.Now;
            
            dbContext.SaveChanges();
        }

        public List<EmployeeModel> GetEmployees()
        {
            return Employees.ToList();
        }

        public string GetEmployeeUsername(Guid employeeId)
        {
            var employee = Employees.FirstOrDefault(e => e.Id.Equals(employeeId));

            return employee == null ? "" : employee.UserName;
        }
    }
}
