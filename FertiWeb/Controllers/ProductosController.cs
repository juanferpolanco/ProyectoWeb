using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FertiWeb.Models;

namespace FertiWeb.Controllers
{
    [Authorize(Users = "administrador@ejemplo.com")]
    public class ProductosController : Controller
    {
        private dbFertiWebEntities db = new dbFertiWebEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tblProducto = db.tblProducto.Include(t => t.tblEmpresa);
            return View(tblProducto.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Index(string prodSearch)
        {
            ViewData["Getproductdetails"] = prodSearch;

            var productos = from m in db.tblProducto select m;

            if (!string.IsNullOrEmpty(prodSearch))
            {
                productos = productos.Where(s => s.nombreProd.Contains(prodSearch));
            }

            return View(await productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.idEmpresa = new SelectList(db.tblEmpresa, "idEmp", "nombreEmp");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,idEmpresa,nombreProd,precioProd")] tblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                db.tblProducto.Add(tblProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpresa = new SelectList(db.tblEmpresa, "idEmp", "nombreEmp", tblProducto.idEmpresa);
            return View(tblProducto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpresa = new SelectList(db.tblEmpresa, "idEmp", "nombreEmp", tblProducto.idEmpresa);
            return View(tblProducto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,idEmpresa,nombreProd,precioProd")] tblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpresa = new SelectList(db.tblEmpresa, "idEmp", "nombreEmp", tblProducto.idEmpresa);
            return View(tblProducto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProducto tblProducto = db.tblProducto.Find(id);
            db.tblProducto.Remove(tblProducto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
