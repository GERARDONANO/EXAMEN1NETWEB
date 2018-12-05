using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen1NETWEB.Models;

namespace Examen1NETWEB.Controllers
{
    public class PedidoController : Controller
    {
        private EXAMEN1NETWEBEntities db = new EXAMEN1NETWEBEntities();

        // GET: Pedido
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Cliente1).Include(p => p.Producto1);
            return View(pedido.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.Cliente, "Id", "Rut");
            ViewBag.Producto = new SelectList(db.Producto, "Id", "Nombre");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cliente,Producto,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
               


               

                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Cliente, "Id", "Rut", pedido.Cliente);
            ViewBag.Producto = new SelectList(db.Producto, "Id", "Nombre", pedido.Producto);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "Id", "Rut", pedido.Cliente);
            ViewBag.Producto = new SelectList(db.Producto, "Id", "Nombre", pedido.Producto);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cliente,Producto,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "Id", "Rut", pedido.Cliente);
            ViewBag.Producto = new SelectList(db.Producto, "Id", "Nombre", pedido.Producto);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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
