using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShopApp.Data;
using CoffeeShopApp.Data.Models;

namespace CoffeeShopApp.Business.RepositoryLogic
{
    public class ProductService : IProductService
    {
        private CoffeeShopDbContext dbContext;

        public ProductService(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<ProductModel> Products => dbContext.Products;

        public string AddProduct(ProductModel newProduct)
        {
            var newEntity = dbContext.Add<ProductModel>(newProduct).Entity;

            dbContext.SaveChanges();

            return newEntity.Name;           
        }

        public bool DeleteProduct(Guid productId)
        {
            var productToDelete = Products.SingleOrDefault(p => p.ProductId.Equals(productId));

            if (productToDelete == null) return false;

            productToDelete.DateDeleted = DateTime.Now;

            return dbContext.SaveChanges() > 0 ? true : false;
        }

        public string EditProduct(ProductModel changedProduct)
        {
            var productToChange = Products.SingleOrDefault(p => p.ProductId.Equals(changedProduct.ProductId));

            var oldName = productToChange.Name;

            productToChange.Name = changedProduct.Name;
            productToChange.Price = changedProduct.Price;

            dbContext.SaveChanges();

            return oldName;
        }

        public ProductModel GetProduct(Guid productId)
        {
            return Products.SingleOrDefault(p => p.ProductId.Equals(productId));
        }

        public string GetProductName(Guid productId)
        {
            var product = Products.SingleOrDefault(p => p.ProductId.Equals(productId));

            return product == null ? "" : product.Name;
        }

        public List<ProductModel> GetProducts()
        {
            return Products.ToList();
        }

        public List<ProductModel> GetProducts(List<Guid> productIds)
        {
           return Products.Where(p => productIds.Contains(p.ProductId)).ToList();   
        }
    }
}
