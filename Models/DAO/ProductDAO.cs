using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class ProductDAO
    {
        private ShopContext db;
        public ProductDAO()
        {
            db = new ShopContext();
        }
        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }

        public List<Product> GetProductsByType(int idType)
        {
            var products = (from p in db.Products
                           where p.productTypeId == idType
                           select p).ToList();
            return products;
        }
    }
}