using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class ProductTypeDAO
    {
        private ShopContext db;
        public ProductTypeDAO()
        {
            db = new ShopContext();
        }

        public List<ProductType> GetProductTypes()
        {
            return db.ProductTypes.ToList();
        }

        public SelectList GetSelectLists()
        {
            var types = db.ProductTypes.ToList();
            var selectList = new SelectList(types, "ID", "Name");
            return selectList;
        }
    }
}