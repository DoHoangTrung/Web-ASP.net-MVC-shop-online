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

        public int Insert (Product p)
        {
            if (p != null)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return p.id;
            }
            else return -1;
        }

        public Product GetProductByID(int id)
        {
            return db.Products.Find(id);
        }

        public void Update(Product pUpdate)
        {
            if (pUpdate != null)
            {
                Product p = db.Products.Find(pUpdate.id);
                p.name = pUpdate.name;
                p.quantity = pUpdate.quantity;
                p.price = pUpdate.price;
                p.productTypeId = pUpdate.productTypeId;
                if (pUpdate.img0 != null)
                {
                    p.img0 = pUpdate.img0;
                }

                if (pUpdate.img1 != null)
                {
                    p.img1 = pUpdate.img1;
                }
                if (pUpdate.img2 != null)
                {
                    p.img2 = pUpdate.img2;
                }
                p.supplier = pUpdate.supplier;
                db.SaveChanges();
            }
        }
    }
}