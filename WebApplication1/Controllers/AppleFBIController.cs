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
    public class AppleFBIController : Controller
    {
        private Database_FYPEntities db = new Database_FYPEntities();

        // GET: /AppleFBI/
        public ActionResult Index()
        {
            return View(db.Apple_vs_FBI_cases.ToList());
        }

        // GET: /AppleFBI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple_vs_FBI_case apple_vs_fbi_case = db.Apple_vs_FBI_cases.Find(id);
            if (apple_vs_fbi_case == null)
            {
                return HttpNotFound();
            }
            return View(apple_vs_fbi_case);
        }

        // GET: /AppleFBI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AppleFBI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Comment,Author,Date_Created")] Apple_vs_FBI_case apple_vs_fbi_case)
        {
            if (ModelState.IsValid)
            {
                apple_vs_fbi_case.Author = User.Identity.Name;
                apple_vs_fbi_case.Date_Created = DateTime.Now;
                db.Apple_vs_FBI_cases.Add(apple_vs_fbi_case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apple_vs_fbi_case);
        }

        // GET: /AppleFBI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple_vs_FBI_case apple_vs_fbi_case = db.Apple_vs_FBI_cases.Find(id);
            if (apple_vs_fbi_case == null)
            {
                return HttpNotFound();
            }
            return View(apple_vs_fbi_case);
        }
        public ActionResult Sentiment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple_vs_FBI_case comment = db.Apple_vs_FBI_cases.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /AppleFBI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Comment,Author,Date_Created")] Apple_vs_FBI_case apple_vs_fbi_case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apple_vs_fbi_case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apple_vs_fbi_case);
        }

        // GET: /AppleFBI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple_vs_FBI_case apple_vs_fbi_case = db.Apple_vs_FBI_cases.Find(id);
            if (apple_vs_fbi_case == null)
            {
                return HttpNotFound();
            }
            return View(apple_vs_fbi_case);
        }

        // POST: /AppleFBI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apple_vs_FBI_case apple_vs_fbi_case = db.Apple_vs_FBI_cases.Find(id);
            db.Apple_vs_FBI_cases.Remove(apple_vs_fbi_case);
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
