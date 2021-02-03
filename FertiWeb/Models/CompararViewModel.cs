using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FertiWeb.Models
{
    public class CompararViewModel
    {
        public int idProducto { get; set; }
        public string nombreProd { get; set; }
        public string nombreEmp { get; set; }
        public decimal precioProd { get; set; }
    }
}