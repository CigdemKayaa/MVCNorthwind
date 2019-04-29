using MVCNorthwind.Models.Data;
using MVCNorthwind.Models.DTO;
using MVCNorthwind.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        NorthwindEntities db = new NorthwindEntities();
        ProductsModel pmodel = new ProductsModel();
        public ActionResult Liste(string name)
        {
            if (name == null)
                name = "";               /* /* arama yaparken sectıgımız name ı yollamak için liste/yazdıgımızname. Liste de arama kısmında name="name" olan parametreyı (name) i yolladık*/
            pmodel.plist = db.Products.Select(x => new ProductsDTO
            {
                CategoryName = x.Categories.CategoryName,
                CompanyName = x.Suppliers.CompanyName,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                Discontinued = x.Discontinued,
                UnitPrice = (decimal)x.UnitPrice

            }).ToList();
            return View(pmodel);
        }
        public ActionResult Detay(int id)
        {
            pmodel.products = db.Products.Find(id);
            //1.yol

            return View(pmodel);
        }
        [HttpGet]
        public ActionResult Guncel(int id)
        {
            pmodel.products = db.Products.Find(id);
            pmodel.CategoriesForDropDown = DoldurCatDropDown();
            pmodel.SuppliersForDropDown = DoldurSupDropDown();
            return View(pmodel);
        }

        private List<SelectListItem> DoldurSupDropDown()
        {
            return db.Suppliers.Select(x => new SelectListItem()
            {
                Text = x.CompanyName,
                Value = x.SupplierID.ToString()
            }).ToList();
        }

        private List<SelectListItem> DoldurCatDropDown()
        {
            return db.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
        }

        [HttpPost]
        public ActionResult Guncel(ProductsModel pm,int id)
        {
            if (ModelState.IsValid)
            {


                //p = db.Products.Find(id);

                ////1.yol
                //p.ProductName = pm.products.ProductName;
                //p.UnitPrice = pm.products.UnitPrice;
                //p.QuantityPerUnit = pm.products.QuantityPerUnit;
                //p.Discontinued = pm.products.Discontinued;

                db.Entry(pm.products).State = EntityState.Modified;


                //3.yol              
                //Mapper.Initialize(x => x.CreateMap<Products, ProductsModel>()); 
                //c = Mapper.Map<Products>(cm.Products);             
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            pmodel.CategoriesForDropDown = DoldurCatDropDown();
            pmodel.SuppliersForDropDown = DoldurSupDropDown();
            return View(pmodel);

        }
        [HttpPost]
        public ActionResult Ekle(ProductsModel pm)
        {
            if (ModelState.IsValid)
            {
                //1.yol
                //Products p = new Products();

                //p.ProductName = pm.products.ProductName;
                //p.Categories.CategoryName = pm.products.Categories.CategoryName;

                //db.Products.Add(p);

                //2.yol
                db.Entry(pm.products).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }

            return View();
        }
    }
}