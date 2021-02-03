using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FertiWeb.Models;

namespace FertiWeb.Controllers
{
    [Authorize]
    public class CompararController : Controller
    {
        private dbFertiWebEntities db = new dbFertiWebEntities();
        // GET: Comparar
        public ActionResult Index()
        {
            //using (Models.dbFertiWebEntities db = new Models.dbFertiWebEntities())
            //{
            //}
            List<CompararViewModel> list = null;
            list = (from d in db.tblProducto
                    select new CompararViewModel
                    {
                        idProducto = d.idProducto,
                        nombreProd = d.nombreProd,
                        precioProd = d.precioProd,
                        nombreEmp = d.tblEmpresa.nombreEmp
                    }).ToList();

            //new
            List<ComEmp2> list2 = null;
            list2 = (from d in db.tblEmpresa
                     select new ComEmp2
                     {
                         idEmpresa = d.idEmp,
                         nombreEmp = d.nombreEmp
                     }).ToList();

            //List<SelectListItem> items = list.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombreProd.ToString() + " - " + d.nombreEmp.ToString(),
            //        Value = d.precioProd.ToString(),
            //        Selected = true
            //    };
            //});

            //new
            List<SelectListItem> items = list2.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreEmp.ToString(),
                    Value = d.idEmpresa.ToString(),
                    Selected = true
                };
            });

            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection precio1, FormCollection precio2)
        {
            //string value1 = precio1["datos1"].ToString();
            //string value2 = precio2["datos2"].ToString();

            //new
            int value1 = int.Parse(precio1["datos1"]);
            int value2 = int.Parse(precio2["datos2"]);
            //new
            //List<ComEmp3> list2 = null;
            //list2 = (from d in db.tblProducto
            //         select new ComEmp3
            //         {
            //             idProducto = d.idProducto,
            //             nombreProd = d.nombreProd,
            //             idEmp = d.idEmpresa
            //         }).Where(s => s.idEmp == int.Parse(value1)).ToList();

            //new
            List<tblProducto> prod1 = db.tblProducto.Where(s => s.idEmpresa == value1).ToList();
            List<tblProducto> prod2 = db.tblProducto.Where(s => s.idEmpresa == value2).ToList();
            ViewBag.emp1 = prod1[0].tblEmpresa.nombreEmp;
            ViewBag.emp2 = prod2[0].tblEmpresa.nombreEmp;
            //new
            //List<ComEmp3> list3 = null;
            //list3 = (from d in db.tblProducto
            //         select new ComEmp3
            //         {
            //             idProducto = d.idProducto,
            //             nombreProd = d.nombreProd,
            //             idEmp = d.idEmpresa
            //         }).Where(s => s.idEmp == int.Parse(value2)).ToList();

            //decimal resultado = Math.Abs(decimal.Parse(value1) - decimal.Parse(value2));

            //new
            //if(list2.Count() > list3.Count())

            //new
            List<ComEmp3> listF = new List<ComEmp3>();
            foreach(var b in prod1)
            {
                foreach(var c in prod2)
                {
                    if(b.nombreProd == c.nombreProd)
                    {
                        listF.Add(new ComEmp3()
                        {
                            idProducto = b.idProducto,
                            nombreProd = b.nombreProd,
                            idEmp = b.idEmpresa,
                            precio1 = b.precioProd,
                            precio2 = c.precioProd
                        });
                    }
                }
            }

            ViewBag.data = value1;
            ViewBag.data2 = value2;
            ViewBag.data3 = listF;

            //if (decimal.Parse(value1) < decimal.Parse(value2))
            //{
            //    ViewBag.resultado = "El producto a comprar es $" + resultado + " más barato" +
            //        " que el producto comparado.";
            //} 
            //else if(decimal.Parse(value1) > decimal.Parse(value2))
            //{
            //    ViewBag.resultado = "El producto a comprar es $" + resultado + " más caro" +
            //        " que el producto comparado.";
            //}
            //else
            //{
            //    ViewBag.resultado = "Los dos productos tienen el mismo precio.";
            //}

            //ViewBag.empresa = db.tblProducto.Where(s => s.id)

            return View("Comparar",listF);
        }

        public ActionResult Comparar()
        {
            return View();
        }

    }
}
