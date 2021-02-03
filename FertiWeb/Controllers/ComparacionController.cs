using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FertiWeb.Models;

namespace FertiWeb.Controllers
{
    public class ComparacionController : Controller
    {
        private dbFertiWebEntities db = new dbFertiWebEntities();

        // GET: Comparacion
        public ActionResult Index()
        {
            var tblComparar = db.tblComparar.Include(t => t.tblProducto).Include(t => t.tblProducto1);
            return View(tblComparar.ToList());
        }

        // GET: Comparacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComparar tblComparar = db.tblComparar.Find(id);
            if (tblComparar == null)
            {
                return HttpNotFound();
            }
            return View(tblComparar);
        }

        // GET: Comparacion/Create
        public ActionResult Create()
        {
            ViewBag.idProductoDos = new SelectList(db.tblProducto, "idProducto", "nombreProd");
            ViewBag.idProductoUno = new SelectList(db.tblProducto, "idProducto", "nombreProd");
            return View();
        }

        // POST: Comparacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComp,idProductoUno,idProductoDos,compPrecio")] tblComparar tblComparar)
        {
            if (ModelState.IsValid)
            {
                db.tblComparar.Add(tblComparar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProductoDos = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoDos);
            ViewBag.idProductoUno = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoUno);
            return View(tblComparar);
        }

        // GET: Comparacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComparar tblComparar = db.tblComparar.Find(id);
            if (tblComparar == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProductoDos = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoDos);
            ViewBag.idProductoUno = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoUno);
            return View(tblComparar);
        }

        // POST: Comparacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idComp,idProductoUno,idProductoDos,compPrecio")] tblComparar tblComparar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblComparar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProductoDos = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoDos);
            ViewBag.idProductoUno = new SelectList(db.tblProducto, "idProducto", "nombreProd", tblComparar.idProductoUno);
            return View(tblComparar);
        }

        // GET: Comparacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComparar tblComparar = db.tblComparar.Find(id);
            if (tblComparar == null)
            {
                return HttpNotFound();
            }
            return View(tblComparar);
        }

        // POST: Comparacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblComparar tblComparar = db.tblComparar.Find(id);
            db.tblComparar.Remove(tblComparar);
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
