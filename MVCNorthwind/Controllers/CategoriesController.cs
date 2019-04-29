using MVCNorthwind.Models.Data;
using MVCNorthwind.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        NorthwindEntities db = new NorthwindEntities();
        CategoriesModel model = new CategoriesModel();
        public ActionResult Liste(string name)
        {
            if (name==null)            
                name = "";
            
            model.clist = db.Categories.Where(x=>x.CategoryName.Contains(name)).ToList();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.Categories = db.Categories.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncel(int id)
        {
          model.Categories= db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncel(int id, CategoriesModel cm)
        {
            if (ModelState.IsValid)  /*modeldekiler geçerliyse demek*/
            {
                Categories secilencategory = db.Categories.Find(id);
                secilencategory.CategoryName = cm.Categories.CategoryName;
                secilencategory.Description = cm.Categories.Description;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(CategoriesModel cm)
        {
            if (ModelState.IsValid)
            {
                Categories c = new Categories();
                //c=cm.Categories;
                //Mapper.Initialize(x => x.CreateMap<Categories, CategoriesModel>()); 
                c.CategoryName = cm.Categories.CategoryName;
                c.Description = cm.Categories.Description;
                //c = Mapper.Map<Categories>(cm.Categories);
                db.Categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            model.Categories = db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sil(int id, bool deger = true)
        {
            Categories c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}