using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FertiWeb.Models
{
    public class ValidarUsuarios
    {
        [Display(Name = "Correo Electrónico")]
        public int Email { get; set; }

        [Display(Name = "Contraseña (Encriptada)")]
        public int PasswordHash { get; set; }
    }
}