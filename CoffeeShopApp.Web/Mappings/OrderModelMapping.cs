using CoffeeShopApp.Business.RepositoryLogic;
using CoffeeShopApp.Data.Models;
using CoffeeShopApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApp.Web.Mappings
{
    public static class OrderModelMapping
    {
        public static List<OrderViewModel> MapOrdersToViewModels(this List<OrderModel> orders, IOrderService _orderService)
        {
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach(var order in orders)
            {
                var newOrder = new OrderViewModel()
                {
                    OrderNumber = order.OrderNumber,
                    OrderId = order.OrderId,
                    EmployeeUserName = _orderService.GetOrderEmployeeUsername(order.EmployeeId),
                    EmployeeId = order.EmployeeId,
                    DateofOrder = order.DateofOrder,
                    DateDeleted = order.DateDeleted,
                    TotalPrice = 0,
                    Products = new List<Guid>()
                };

                order.OrderedProducts = _orderService.GetOrderedProducts(order.OrderId);

                foreach (var op in order.OrderedProducts)
                {
                    newOrder.Products.Add(op.ProductId);
                    newOrder.TotalPrice += _orderService.GetOrderedProductPrice(op.ProductId);
                }

                orderViewModels.Add(newOrder);

            }

            return orderViewModels;
        }

        public static OrderViewModel MapOrderToViewModel(this OrderModel order, IOrderService _orderService)
        {
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                OrderNumber = order.OrderNumber,
                OrderId = order.OrderId,
                DateofOrder = order.DateofOrder,
                EmployeeUserName = _orderService.GetOrderEmployeeUsername(order.EmployeeId),
                EmployeeId = order.EmployeeId,
                DateDeleted = order.DateDeleted,
                TotalPrice = 0,
                Products = new List<Guid>()
            };

            order.OrderedProducts = _orderService.GetOrderedProducts(order.OrderId);

            foreach (var op in order.OrderedProducts)
            {
                orderViewModel.Products.Add(op.ProductId);
                orderViewModel.TotalPrice += _orderService.GetOrderedProductPrice(op.ProductId);
            }

            return orderViewModel;
        }

        public static OrderModel MapViewModelToOrder(this OrderViewModel order, IOrderService _orderService)
        {
            OrderModel orderModel = new OrderModel()
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                DateofOrder = order.DateofOrder,
                DateDeleted = order.DateDeleted,
                EmployeeId = order.EmployeeId,
                OrderedProducts = new List<OrderedProducts>()
            };

            foreach(var op in order.Products)
            {
                OrderedProducts orderedProduct = new OrderedProducts()
                {
                    OrderId = order.OrderId,
                    ProductId = op
                };

                orderModel.OrderedProducts.Add(orderedProduct);
            }

            return orderModel;
        }
    }
}
