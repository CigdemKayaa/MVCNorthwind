using MVCNorthwind.Models.Data;
using MVCNorthwind.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind.Models.View
{
    public class ProductsModel
    {
        public List<ProductsDTO> plist { get; set; } /*tum listeyı goruntulerken liste cagırıyoruz*/
        public Products products { get; set; } /*guncelleme ve sılme ıslemı yaparken tek bır kategorı getırıyoruz*/
        public List<SelectListItem> CategoriesForDropDown { get; set; }
        public List<SelectListItem> SuppliersForDropDown { get; set; }
        public int TotalPage { get; set; }
        public decimal TotalStock { get; set; }
        public decimal PageStock { get; set; }
    }
}