using CoffeeShopApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public interface IProductService
    {
        IQueryable<ProductModel> Products { get; }

        List<ProductModel> GetProducts();

        List<ProductModel> GetProducts(List<Guid> productIds);

        ProductModel GetProduct(Guid productId);

        bool DeleteProduct(Guid productId);

        string GetProductName(Guid productId);

        string AddProduct(ProductModel newProduct);

        string EditProduct(ProductModel changedProduct);
    }
}
