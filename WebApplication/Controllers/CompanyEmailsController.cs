using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyEmailsController : Controller
    {
        private DrivingSchoolEntities db = new DrivingSchoolEntities();

        // GET: CompanyEmails
        public ActionResult Index()
        {
            return View(db.CompanyEmails.ToList());
        }

        // GET: CompanyEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmail companyEmail = db.CompanyEmails.Find(id);
            if (companyEmail == null)
            {
                return HttpNotFound();
            }
            return View(companyEmail);
        }

        // GET: CompanyEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyEmailId,EmailAddress,Password")] CompanyEmail companyEmail)
        {
            if (ModelState.IsValid)
            {
                db.CompanyEmails.Add(companyEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyEmail);
        }

        // GET: CompanyEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmail companyEmail = db.CompanyEmails.Find(id);
            if (companyEmail == null)
            {
                return HttpNotFound();
            }
            return View(companyEmail);
        }

        // POST: CompanyEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyEmailId,EmailAddress,Password")] CompanyEmail companyEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyEmail);
        }

        // GET: CompanyEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmail companyEmail = db.CompanyEmails.Find(id);
            if (companyEmail == null)
            {
                return HttpNotFound();
            }
            return View(companyEmail);
        }

        // POST: CompanyEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyEmail companyEmail = db.CompanyEmails.Find(id);
            db.CompanyEmails.Remove(companyEmail);
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
