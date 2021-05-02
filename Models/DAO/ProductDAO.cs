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
        public IEnumerable<Product> GetProducts()
        {
            var products = db.Products;
            return products;
        }
    }
}