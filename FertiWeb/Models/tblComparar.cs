//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FertiWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblComparar
    {
        public int idComp { get; set; }
        public Nullable<int> idProductoUno { get; set; }
        public Nullable<int> idProductoDos { get; set; }
        public Nullable<decimal> compPrecio { get; set; }
    
        public virtual tblProducto tblProducto { get; set; }
        public virtual tblProducto tblProducto1 { get; set; }
    }
}
