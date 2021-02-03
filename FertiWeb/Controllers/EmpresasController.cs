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
    [Authorize(Users = "administrador@ejemplo.com")]
    public class EmpresasController : Controller
    {
        private dbFertiWebEntities db = new dbFertiWebEntities();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.tblEmpresa.ToList());
        }

    // GET: Empresas/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa tblEmpresa = db.tblEmpresa.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmp,nombreEmp,ciudadEmp")] tblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpresa.Add(tblEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa tblEmpresa = db.tblEmpresa.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmp,nombreEmp,ciudadEmp")] tblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa tblEmpresa = db.tblEmpresa.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpresa tblEmpresa = db.tblEmpresa.Find(id);
            db.tblEmpresa.Remove(tblEmpresa);
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
