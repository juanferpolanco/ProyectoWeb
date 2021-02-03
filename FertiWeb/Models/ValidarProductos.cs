using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FertiWeb.Models
{
    public class ValidarProductos
    {
        //[Display(Name = "ID")]
        //public int idProducto { get; set; }

        //[Display(Name = "Empresa")]
        //public int idEmpresa { get; set; }

        [Display(Name = "Nombre")]
        public string nombreProd { get; set; }

        [Display(Name = "Precio")]
        public decimal precioProd { get; set; }
    }
}