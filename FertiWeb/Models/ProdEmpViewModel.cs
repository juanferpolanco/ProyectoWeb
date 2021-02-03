using System.Collections.Generic;
using System.Web.Mvc;

namespace FertiWeb.Models
{
    public class ProdEmpViewModel
    {
        public List<tblProducto> Productos { get; set; }
        public SelectList Empresas { get; set; }
        public string ProdEmp { set; get; }
        public string SearchString { set; get; }
    }
}