using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HuntingController : Controller
    {
        private Database_FYPEntities db = new Database_FYPEntities();

        // GET: /Hunting/
        public ActionResult Index()
        {
            return View(db.Huntings.ToList());
        }

        // GET: /Hunting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        // GET: /Hunting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Hunting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Comment,Author,Date_Created")] Hunting hunting)
        {
            if (ModelState.IsValid)
            {
                hunting.Author = User.Identity.Name;
                hunting.Date_Created = DateTime.Now;
                db.Huntings.Add(hunting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hunting);
        }

        // GET: /Hunting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        // POST: /Hunting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Comment,Author,Date_Created")] Hunting hunting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hunting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hunting);
        }
        public ActionResult Sentiment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting comment = db.Huntings.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        // GET: /Hunting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        // POST: /Hunting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hunting hunting = db.Huntings.Find(id);
            db.Huntings.Remove(hunting);
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
