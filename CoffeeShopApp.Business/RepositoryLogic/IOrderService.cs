using CoffeeShopApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public interface IOrderService
    {
        IQueryable<OrderModel> Orders { get; }

        IQueryable<OrderedProducts> OrderedProducts { get; }

        OrderModel GetOrder(Guid orderId);

        List<OrderModel> GetOrders();

        List<OrderModel> GetOrders(Guid employeeId);

        int GetOrderNumber(Guid orderId);

        List<OrderedProducts> GetOrderedProducts(Guid orderId);

        float GetOrderedProductPrice(Guid orderedProductId);

        string GetOrderEmployeeUsername(Guid employeeId);

        int AddOrder(OrderModel newOrder);

        void EditOrder(OrderModel changedOrder);

        bool DeleteOrder(Guid orderId);
      
    }
}
