using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopApp.Business.RepositoryLogic;
using CoffeeShopApp.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            if(_productService.DeleteProduct(id))
            {
                TempData["ProductInfo"] = "Product \"" + _productService.GetProductName(id) + "\" is deleted.";
            }
            else
            {
                TempData["ProductInfo"] = "Error occurred.";
            }
           
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View("AddOrChange");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ProductModel newProduct)
        {
            if (!ModelState.IsValid)
                return View("AddOrChange", newProduct);

            var name = _productService.AddProduct(newProduct);

            TempData["ProductInfo"] = "Product \"" + name + "\" is added.";

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var productToChange = _productService.GetProduct(id);

            if(productToChange == null)
            {
                TempData["ProductInfo"] = "Product doesn't exists.";

                return RedirectToAction("Index");
            }

            return View("AddOrChange", productToChange);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(ProductModel changedProduct)
        {
            if (!ModelState.IsValid)
                return View("AddOrChange", changedProduct);

            var oldName = _productService.EditProduct(changedProduct);

            TempData["ProductInfo"] = "Product \"" + oldName + "\" is changed.";

            return RedirectToAction("Index");
        }
    }
}