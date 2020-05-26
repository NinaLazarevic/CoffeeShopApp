using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShopApp.Data;
using CoffeeShopApp.Data.Models;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public class OrderService : IOrderService
    {
        private CoffeeShopDbContext dbContext;

        public OrderService(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<OrderModel> Orders => dbContext.Orders;

        public IQueryable<OrderedProducts> OrderedProducts => dbContext.OrderedProducts;

        public int AddOrder(OrderModel newOrder)
        {
            newOrder.OrderNumber = Orders.Count() + 1;

            var entity = dbContext.Add<OrderModel>(newOrder).Entity;

            dbContext.SaveChanges();

            return entity.OrderNumber;
        }

        public bool DeleteOrder(Guid orderId)
        {
            var orderToDelete = Orders.SingleOrDefault(o => o.OrderId.Equals(orderId));

            if (orderToDelete == null) return false;

            orderToDelete.DateDeleted = DateTime.Now;

            return dbContext.SaveChanges() > 0 ? true : false; ;
        }

        public void EditOrder(OrderModel changedOrder)
        {
            var orderToChange = Orders.SingleOrDefault(o => o.OrderId.Equals(changedOrder.OrderId));

            //get old ordered products
            orderToChange.OrderedProducts = OrderedProducts.Where(op => op.OrderId.Equals(orderToChange.OrderId)).ToList();

            //if product doesn't exists in old order, add it
            foreach (var op in changedOrder.OrderedProducts)
            {
                if (orderToChange.OrderedProducts.SingleOrDefault(o => o.ProductId.Equals(op.ProductId)) == null)
                {
                    //orderToChange.OrderedProducts.Add(op);
                    dbContext.Add<OrderedProducts>(op);
                }
            }

            //if product doesn't exists in changed order, delete it
            foreach(var op in orderToChange.OrderedProducts)
            {
                if(changedOrder.OrderedProducts.SingleOrDefault(o => o.ProductId.Equals(op.ProductId)) == null)
                {
                    dbContext.Remove<OrderedProducts>(op);
                }
            }

            dbContext.SaveChanges();
        }

        public OrderModel GetOrder(Guid orderId)
        {
            return Orders.SingleOrDefault(o => o.OrderId.Equals(orderId));
        }

        public float GetOrderedProductPrice(Guid orderedProductId)
        {
            return dbContext.Products.SingleOrDefault(p => p.ProductId.Equals(orderedProductId)).Price;
        }

        public List<OrderedProducts> GetOrderedProducts(Guid orderId)
        {
            return OrderedProducts.Where(op => op.OrderId.Equals(orderId)).ToList();
        }

        public string GetOrderEmployeeUsername(Guid employeeId)
        {
            return dbContext.Users.SingleOrDefault(e => e.Id.Equals(employeeId)).UserName;
        }

        public int GetOrderNumber(Guid orderId)
        {
            var order = Orders.SingleOrDefault(o => o.OrderId.Equals(orderId));

            return order == null ? -1 : order.OrderNumber;
        }

        public List<OrderModel> GetOrders()
        {
            return Orders.ToList();
        }

        public List<OrderModel> GetOrders(Guid employeeId)
        {
            return Orders.Where(o => o.Employee.Id.Equals(employeeId)).ToList();
        }
    }
}
