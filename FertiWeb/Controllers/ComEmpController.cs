using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FertiWeb.Controllers
{
    [Authorize]
    public class ComEmpController : Controller
    {
        //public ActionResult Index()
        //{
        //    //using (Models.dbFertiWebEntities db = new Models.dbFertiWebEntities())
        //    //{
        //    //}
        //    List<CompararViewModel> list = null;
        //    list = (from d in db.tblProducto
        //            select new CompararViewModel
        //            {
        //                idProducto = d.idProducto,
        //                nombreProd = d.nombreProd,
        //                precioProd = d.precioProd,
        //                nombreEmp = d.tblEmpresa.nombreEmp
        //            }).ToList();

        //    List<SelectListItem> items = list.ConvertAll(d =>
        //    {
        //        return new SelectListItem()
        //        {
        //            Text = d.nombreProd.ToString() + " - " + d.nombreEmp.ToString(),
        //            Value = d.precioProd.ToString(),
        //            Selected = true
        //        };
        //    });

        //    ViewBag.items = items;

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(FormCollection precio1, FormCollection precio2)
        //{
        //    string value1 = precio1["datos1"].ToString();
        //    string value2 = precio2["datos2"].ToString();

        //    decimal resultado = Math.Abs(decimal.Parse(value1) - decimal.Parse(value2));

        //    ViewBag.data = value1;
        //    ViewBag.data2 = value2;

        //    if (decimal.Parse(value1) < decimal.Parse(value2))
        //    {
        //        ViewBag.resultado = "El producto a comprar es $" + resultado + " más barato" +
        //            " que el producto comparado.";
        //    }
        //    else if (decimal.Parse(value1) > decimal.Parse(value2))
        //    {
        //        ViewBag.resultado = "El producto a comprar es $" + resultado + " más caro" +
        //            " que el producto comparado.";
        //    }
        //    else
        //    {
        //        ViewBag.resultado = "Los dos productos tienen el mismo precio.";
        //    }

        //    return View("Comparar");
        //}

        //public ActionResult Comparar()
        //{
        //    return View();
        //}
    }
}