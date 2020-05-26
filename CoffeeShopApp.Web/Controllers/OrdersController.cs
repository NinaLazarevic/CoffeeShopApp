using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopApp.Business.RepositoryLogic;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopApp.Web.Mappings;
using CoffeeShopApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CoffeeShopApp.Data.Models;

namespace CoffeeShopApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderService _orderService;
        private UserManager<EmployeeModel> _userManager;

        public OrdersController(IOrderService orderService, UserManager<EmployeeModel> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if(User.IsInRole("Admin"))
                return View(_orderService.GetOrders().MapOrdersToViewModels(_orderService));

            return View(_orderService.GetOrders(Guid.Parse(_userManager.GetUserId(User)))
                .MapOrdersToViewModels(_orderService));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var orderToChange = _orderService.GetOrder(id);

            if (orderToChange == null)
            {
                TempData["OrderInfo"] = "Order doesn't exists.";

                return RedirectToAction("Index");
            }

            return View("AddOrChange", orderToChange.MapOrderToViewModel(_orderService));
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel changedOrder)
        {
            if(!ModelState.IsValid)
                return View("AddOrChange", changedOrder);

            _orderService.EditOrder(changedOrder.MapViewModelToOrder(_orderService));

            TempData["OrderInfo"] = "Order with number \"" + _orderService.GetOrderNumber(changedOrder.OrderId) + "\" is changed.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var newOrder = new OrderViewModel()
            {
                TotalPrice = 0,
                EmployeeUserName = _userManager.GetUserName(User),
                Products = new List<Guid>()

            };
            return View("AddOrChange", newOrder);
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel newOrder)
        {
            if (!ModelState.IsValid)
                return View("AddOrChange", newOrder);

            newOrder.EmployeeId = Guid.Parse(_userManager.GetUserId(User)); /*Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));*/
            newOrder.DateofOrder = DateTime.Now;

            var orderNum = _orderService.AddOrder(newOrder.MapViewModelToOrder(_orderService));

            TempData["OrderInfo"] = "Order with number \"" + orderNum + "\" is added";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            if(_orderService.DeleteOrder(id))
            {
                TempData["OrderInfo"] = "Order with number \"" + _orderService.GetOrderNumber(id) +"\" is deleted";
            }
            else
            {
                TempData["OrderInfo"] = "Error occurred";
            }
            return RedirectToAction("Index");
        }
    }
}