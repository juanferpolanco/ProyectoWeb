using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FertiWeb.Models
{
    public class ValidarEmpresa
    {
        //public int idEmp { get; set; }

        [Display(Name = "Nombre")]
        public string nombreEmp{ get; set; }

        [Display(Name = "Ciudad")]
        public string ciudadEmp { get; set; }
    }
}