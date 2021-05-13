using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using PagedList;
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
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            //load product type dropdownlist
            ProductTypeDAO typeDao = new ProductTypeDAO();
            var productTypes = typeDao.GetSelectLists();
            ViewBag.productTypes = productTypes;

            //load list products
            var products = Session["productsShowing"] as List<Product>;
            if (products == null)
            {
                ProductDAO proDao = new ProductDAO();
                products = proDao.GetProducts();
            }

            return View(products.ToPagedList(page,pageSize));
        }

        [HttpPost]
        public ActionResult Index(FormCollection form, int page = 1, int pageSize = 2)
        {
            ProductTypeDAO typeDao = new ProductTypeDAO();
            var productTypes = typeDao.GetSelectLists();
            ViewBag.productTypes = productTypes;

            int typeID;
            bool check = int.TryParse(form["ddlTypes"], out typeID);

            ProductDAO proDao = new ProductDAO();

            List<Product> productsShowing = Session["productsShowing"] as List<Product>;

            List<Product> products = new List<Product>();

            if (check)
            {
                products = proDao.GetProductsByType(productsShowing,typeID);
            }
            else
            {
                products = productsShowing;
            }

            return View(products.ToPagedList(page, pageSize));
        }

        [HttpPost]
        public ActionResult Search(string textSearch)
        {
            ProductDAO pDao = new ProductDAO();
            var proSearch = pDao.Search(textSearch);

            Session["productsShowing"] = proSearch;
            return RedirectToAction("Index", "Products");
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
                int id = dao.Insert(pro);

                return RedirectToAction("Index","Products");
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
            ProductDAO dao = new ProductDAO();
            Product p = dao.GetProductByID(id);
            return View(p);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(Product pDel)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                dao.Delete(pDel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
