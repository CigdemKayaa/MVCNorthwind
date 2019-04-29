using MVCNorthwind.Models.Data;
using MVCNorthwind.Models.DTO;
using MVCNorthwind.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind.Controllers
{
    public class ProductsPagingController : Controller
    {
        // GET: ProductsPaging
        NorthwindEntities db = new NorthwindEntities();
        ProductsModel pm = new ProductsModel();
        public ActionResult Liste(int id)
        {
          pm.TotalStock=(decimal)  db.Products.Sum(x => x.UnitsInStock * x.UnitPrice);
           
            pm.TotalPage=Convert.ToInt32(Math.Ceiling(Convert.ToDecimal( db.Products.Count())/10));//toplam data sayısını hesapladık.
            pm.plist = db.Products.OrderBy(x=>x.ProductID).Skip((id-1)*10).Take(10).Select(x=> new ProductsDTO
            {
                ProductID=x.ProductID,
                ProductName=x.ProductName,
                CompanyName=x.Suppliers.CompanyName,
                CategoryName=x.Categories.CategoryName,
                UnitPrice=(decimal)x.UnitPrice,
                Discontinued=x.Discontinued
            }).ToList();
            pm.PageStock = pm.plist.Sum(x => x.UnitPrice);
            return View(pm);
        }
    }
}