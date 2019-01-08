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
    public class tbl_AseguradorasController : Controller
    {
        private bd_SegurosFalabellaEntities db = new bd_SegurosFalabellaEntities();

        // GET: tbl_Aseguradoras
        public ActionResult Index()
        {
            return View(db.tbl_Aseguradoras.ToList());
        }

        // GET: tbl_Aseguradoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aseguradoras tbl_Aseguradoras = db.tbl_Aseguradoras.Find(id);
            if (tbl_Aseguradoras == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aseguradoras);
        }

        // GET: tbl_Aseguradoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Aseguradoras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aseg_IdAseguradoraPk,aseg_NombreAseguradora")] tbl_Aseguradoras tbl_Aseguradoras)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Aseguradoras.Add(tbl_Aseguradoras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Aseguradoras);
        }

        // GET: tbl_Aseguradoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aseguradoras tbl_Aseguradoras = db.tbl_Aseguradoras.Find(id);
            if (tbl_Aseguradoras == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aseguradoras);
        }

        // POST: tbl_Aseguradoras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aseg_IdAseguradoraPk,aseg_NombreAseguradora")] tbl_Aseguradoras tbl_Aseguradoras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Aseguradoras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Aseguradoras);
        }

        // GET: tbl_Aseguradoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aseguradoras tbl_Aseguradoras = db.tbl_Aseguradoras.Find(id);
            if (tbl_Aseguradoras == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aseguradoras);
        }

        // POST: tbl_Aseguradoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Aseguradoras tbl_Aseguradoras = db.tbl_Aseguradoras.Find(id);
            db.tbl_Aseguradoras.Remove(tbl_Aseguradoras);
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
