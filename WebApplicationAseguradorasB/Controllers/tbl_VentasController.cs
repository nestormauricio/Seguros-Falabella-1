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
    public class tbl_VentasController : Controller
    {
        private bd_SegurosFalabellaEntities db = new bd_SegurosFalabellaEntities();

        // GET: tbl_Ventas
        public ActionResult Index()
        {
            var tbl_Ventas = db.tbl_Ventas.Include(t => t.tbl_Clientes).Include(t => t.tbl_Productos);
            return View(tbl_Ventas.ToList());
        }

        // GET: tbl_Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ventas tbl_Ventas = db.tbl_Ventas.Find(id);
            if (tbl_Ventas == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ventas);
        }

        // GET: tbl_Ventas/Create
        public ActionResult Create()
        {
            ViewBag.vent_IdClienteFk = new SelectList(db.tbl_Clientes, "clie_IdClientePk", "clie_Descripcion");
            ViewBag.vent_IdProductoFk = new SelectList(db.tbl_Productos, "prod_IdProductoPk", "prod_Descripcion");
            return View();
        }

        // POST: tbl_Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vent_IdVentasPk,vent_FechaVenta,vent_IdClienteFk,vent_IdProductoFk")] tbl_Ventas tbl_Ventas)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Ventas.Add(tbl_Ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vent_IdClienteFk = new SelectList(db.tbl_Clientes, "clie_IdClientePk", "clie_Descripcion", tbl_Ventas.vent_IdClienteFk);
            ViewBag.vent_IdProductoFk = new SelectList(db.tbl_Productos, "prod_IdProductoPk", "prod_Descripcion", tbl_Ventas.vent_IdProductoFk);
            return View(tbl_Ventas);
        }

        // GET: tbl_Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ventas tbl_Ventas = db.tbl_Ventas.Find(id);
            if (tbl_Ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.vent_IdClienteFk = new SelectList(db.tbl_Clientes, "clie_IdClientePk", "clie_Descripcion", tbl_Ventas.vent_IdClienteFk);
            ViewBag.vent_IdProductoFk = new SelectList(db.tbl_Productos, "prod_IdProductoPk", "prod_Descripcion", tbl_Ventas.vent_IdProductoFk);
            return View(tbl_Ventas);
        }

        // POST: tbl_Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vent_IdVentasPk,vent_FechaVenta,vent_IdClienteFk,vent_IdProductoFk")] tbl_Ventas tbl_Ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vent_IdClienteFk = new SelectList(db.tbl_Clientes, "clie_IdClientePk", "clie_Descripcion", tbl_Ventas.vent_IdClienteFk);
            ViewBag.vent_IdProductoFk = new SelectList(db.tbl_Productos, "prod_IdProductoPk", "prod_Descripcion", tbl_Ventas.vent_IdProductoFk);
            return View(tbl_Ventas);
        }

        // GET: tbl_Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ventas tbl_Ventas = db.tbl_Ventas.Find(id);
            if (tbl_Ventas == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ventas);
        }

        // POST: tbl_Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Ventas tbl_Ventas = db.tbl_Ventas.Find(id);
            db.tbl_Ventas.Remove(tbl_Ventas);
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
