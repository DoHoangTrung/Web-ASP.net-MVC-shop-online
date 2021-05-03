using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            ProductTypeDAO typeDao = new ProductTypeDAO();
            var productTypes = typeDao.GetSelectLists();
            ViewBag.productTypes = productTypes;

            ProductDAO proDao = new ProductDAO();
            var products = proDao.GetProducts();

            return View(products);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ProductTypeDAO typeDao = new ProductTypeDAO();
            var productTypes = typeDao.GetSelectLists();
            ViewBag.productTypes = productTypes;

            int typeID;
            bool check = int.TryParse(form["ddlTypes"], out typeID);
            if (check)
            {
                ProductDAO proDao = new ProductDAO();
                var products = proDao.GetProductsByType(typeID);

                return View(products);
            }
            else
            {
                ProductDAO proDao = new ProductDAO();
                var products = proDao.GetProducts();

                return View(products);
            }
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ProductTypeDAO typeDAO = new ProductTypeDAO();
            var types = typeDAO.GetSelectLists();
            Session["types"] = types;
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                int id=dao.Insert(pro);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductTypeDAO typeDAO = new ProductTypeDAO();
            ProductDAO proDAO = new ProductDAO();

            Product product = proDAO.GetProductByID(id);
            Session["product"] = product;

            var types = typeDAO.GetSelectLists(product.productTypeId.GetValueOrDefault());
            Session["types"] = types;

            return View();
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                dao.Update(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
