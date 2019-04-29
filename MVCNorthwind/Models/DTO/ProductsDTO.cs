using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNorthwind.Models.DTO
{
    public class ProductsDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public Decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}