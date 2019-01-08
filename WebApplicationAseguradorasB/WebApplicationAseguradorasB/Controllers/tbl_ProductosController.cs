using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationAseguradorasB.Models;

namespace WebApplicationAseguradorasB.Controllers
{
    public class tbl_ProductosController : Controller
    {
        private bd_SegurosFalabellaEntities db = new bd_SegurosFalabellaEntities();

        // GET: tbl_Productos
        public ActionResult Index()
        {
            var tbl_Productos = db.tbl_Productos.Include(t => t.tbl_Aseguradoras);
            return View(tbl_Productos.ToList());
        }

        // GET: tbl_Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Productos tbl_Productos = db.tbl_Productos.Find(id);
            if (tbl_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Productos);
        }

        // GET: tbl_Productos/Create
        public ActionResult Create()
        {
            ViewBag.prod_IdAseguradora_Fk = new SelectList(db.tbl_Aseguradoras, "aseg_IdAseguradoraPk", "aseg_NombreAseguradora");
            return View();
        }

        // POST: tbl_Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prod_IdProductoPk,prod_Descripcion,prod_Prima,prod_Cobertura,prod_Asistencia,prod_MontoVenta,prod_IdAseguradora_Fk")] tbl_Productos tbl_Productos)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Productos.Add(tbl_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prod_IdAseguradora_Fk = new SelectList(db.tbl_Aseguradoras, "aseg_IdAseguradoraPk", "aseg_NombreAseguradora", tbl_Productos.prod_IdAseguradora_Fk);
            return View(tbl_Productos);
        }

        // GET: tbl_Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Productos tbl_Productos = db.tbl_Productos.Find(id);
            if (tbl_Productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.prod_IdAseguradora_Fk = new SelectList(db.tbl_Aseguradoras, "aseg_IdAseguradoraPk", "aseg_NombreAseguradora", tbl_Productos.prod_IdAseguradora_Fk);
            return View(tbl_Productos);
        }

        // POST: tbl_Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prod_IdProductoPk,prod_Descripcion,prod_Prima,prod_Cobertura,prod_Asistencia,prod_MontoVenta,prod_IdAseguradora_Fk")] tbl_Productos tbl_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prod_IdAseguradora_Fk = new SelectList(db.tbl_Aseguradoras, "aseg_IdAseguradoraPk", "aseg_NombreAseguradora", tbl_Productos.prod_IdAseguradora_Fk);
            return View(tbl_Productos);
        }

        // GET: tbl_Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Productos tbl_Productos = db.tbl_Productos.Find(id);
            if (tbl_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Productos);
        }

        // POST: tbl_Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Productos tbl_Productos = db.tbl_Productos.Find(id);
            db.tbl_Productos.Remove(tbl_Productos);
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
