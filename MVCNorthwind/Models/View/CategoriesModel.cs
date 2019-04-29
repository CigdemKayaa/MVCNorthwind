using MVCNorthwind.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNorthwind.Models.View
{
    public class CategoriesModel
    {
        public List<Categories> clist { get; set; }
        public Categories Categories { get; set; }
    }
}