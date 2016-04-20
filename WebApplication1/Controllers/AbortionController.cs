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
    public class AbortionController : Controller
    {
        private Database_FYPEntities db = new Database_FYPEntities();

        // GET: /Abortion/
        public ActionResult Index()
        {
            return View(db.Abortions.ToList());
        }

        // GET: /Abortion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abortion abortion = db.Abortions.Find(id);
            if (abortion == null)
            {
                return HttpNotFound();
            }
            return View(abortion);
        }

        // GET: /Abortion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Abortion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Comment,Author,Date_Created")] Abortion abortion)
        {
            if (ModelState.IsValid)
            {
                abortion.Author = User.Identity.Name;
                abortion.Date_Created = DateTime.Now;
                db.Abortions.Add(abortion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abortion);
        }

        // GET: /Abortion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abortion abortion = db.Abortions.Find(id);
            if (abortion == null)
            {
                return HttpNotFound();
            }
            return View(abortion);
        }
        public ActionResult Sentiment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abortion comment = db.Abortions.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Abortion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Comment,Author,Date_Created")] Abortion abortion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abortion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abortion);
        }

        // GET: /Abortion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abortion abortion = db.Abortions.Find(id);
            if (abortion == null)
            {
                return HttpNotFound();
            }
            return View(abortion);
        }

        // POST: /Abortion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abortion abortion = db.Abortions.Find(id);
            db.Abortions.Remove(abortion);
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
