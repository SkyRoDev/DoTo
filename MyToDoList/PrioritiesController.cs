using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyToDoList
{
    public class PrioritiesController : Controller
    {
        private ToDoListEntities db = new ToDoListEntities();

        // GET: Priorities
        public ActionResult Index()
        {
            return View(db.Priorities.ToList());
        }

        // GET: Priorities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorities priorities = db.Priorities.Find(id);
            if (priorities == null)
            {
                return HttpNotFound();
            }
            return View(priorities);
        }

        // GET: Priorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriorityId,Descryption")] Priorities priorities)
        {
            if (ModelState.IsValid)
            {
                db.Priorities.Add(priorities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priorities);
        }

        // GET: Priorities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorities priorities = db.Priorities.Find(id);
            if (priorities == null)
            {
                return HttpNotFound();
            }
            return View(priorities);
        }

        // POST: Priorities/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriorityId,Descryption")] Priorities priorities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priorities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priorities);
        }

        // GET: Priorities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorities priorities = db.Priorities.Find(id);
            if (priorities == null)
            {
                return HttpNotFound();
            }
            return View(priorities);
        }

        // POST: Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priorities priorities = db.Priorities.Find(id);
            db.Priorities.Remove(priorities);
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
