using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconUniversity.Models;

namespace LexiconUniversity.Controllers
{
    public class PhoneNumbersController : Controller
    {
        private LexiconUniversityContext db = new LexiconUniversityContext();

        // GET: PhoneNumbers
        public ActionResult Index(int? studentId)
        {
            var phoneNumbers = db.PhoneNumbers.Include(p => p.Student);

            if (studentId.HasValue)
            {
                phoneNumbers = phoneNumbers.Where(p => p.StudentId == studentId);
            }

            ViewBag.StudentId = studentId;
            return View(phoneNumbers.ToList());
        }

        // GET: PhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Create
        public ActionResult Create(int? studentId)
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", studentId);
            return View();
        }

        // POST: PhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,StudentId")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.PhoneNumbers.Add(phoneNumber);
                db.SaveChanges();
                return RedirectToAction("Details", "Students", new { id = phoneNumber.StudentId });
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", phoneNumber.StudentId);
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", phoneNumber.StudentId);
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,StudentId")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", phoneNumber.StudentId);
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            db.PhoneNumbers.Remove(phoneNumber);
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
