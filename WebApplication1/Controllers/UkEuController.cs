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
    public class UkEuController : Controller
    {
        private Database_FYPEntities db = new Database_FYPEntities();

        // GET: /UkEu/
        public ActionResult Index()
        {
            return View(db.UK_better_of_outside_the_EUs.ToList());
        }

        // GET: /UkEu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UK_better_of_outside_the_EU uk_better_of_outside_the_eu = db.UK_better_of_outside_the_EUs.Find(id);
            if (uk_better_of_outside_the_eu == null)
            {
                return HttpNotFound();
            }
            return View(uk_better_of_outside_the_eu);
        }

        // GET: /UkEu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UkEu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Comment,Author,Date_Created")] UK_better_of_outside_the_EU uk_better_of_outside_the_eu)
        {
            if (ModelState.IsValid)
            {
                uk_better_of_outside_the_eu.Author = User.Identity.Name;
                uk_better_of_outside_the_eu.Date_Created = DateTime.Now;
                db.UK_better_of_outside_the_EUs.Add(uk_better_of_outside_the_eu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uk_better_of_outside_the_eu);
        }

        // GET: /UkEu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UK_better_of_outside_the_EU uk_better_of_outside_the_eu = db.UK_better_of_outside_the_EUs.Find(id);
            if (uk_better_of_outside_the_eu == null)
            {
                return HttpNotFound();
            }
            return View(uk_better_of_outside_the_eu);
        }

        public ActionResult Sentiment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UK_better_of_outside_the_EU comment = db.UK_better_of_outside_the_EUs.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        // POST: /UkEu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Comment,Author,Date_Created")] UK_better_of_outside_the_EU uk_better_of_outside_the_eu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uk_better_of_outside_the_eu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uk_better_of_outside_the_eu);
        }

        // GET: /UkEu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UK_better_of_outside_the_EU uk_better_of_outside_the_eu = db.UK_better_of_outside_the_EUs.Find(id);
            if (uk_better_of_outside_the_eu == null)
            {
                return HttpNotFound();
            }
            return View(uk_better_of_outside_the_eu);
        }

        // POST: /UkEu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UK_better_of_outside_the_EU uk_better_of_outside_the_eu = db.UK_better_of_outside_the_EUs.Find(id);
            db.UK_better_of_outside_the_EUs.Remove(uk_better_of_outside_the_eu);
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
