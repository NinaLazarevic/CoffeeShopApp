using CoffeeShopApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public interface IEmployeeService
    {
        IQueryable<EmployeeModel> Employees { get; }

        List<EmployeeModel> GetEmployees();

        void DeleteEmployee(Guid employeeId);

        string GetEmployeeUsername(Guid employeeId);
    }
}
