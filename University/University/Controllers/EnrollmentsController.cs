using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class EnrollmentsController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollment = db.Enrollment.Include(e => e.Course).Include(e => e.Student).Where(e => e.IsDeleted == false && e.Course.IsDeleted == false && e.Student.IsDeleted == false);
            return View(enrollment.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null || enrollment.IsDeleted)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Course.Where(c => c.IsDeleted == false), "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Student.Where(s => s.IsDeleted == false), "StudentID", "LastName");
            return View();
        }

        // POST: Enrollments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,Grade,CourseID,StudentID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Course.Where(c => c.IsDeleted == false), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student.Where(s => s.IsDeleted == false), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null || enrollment.IsDeleted)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Course.Where(c => c.IsDeleted == false), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student.Where(s => s.IsDeleted == false), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,Grade,CourseID,StudentID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Course.Where(c => c.IsDeleted == false), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student.Where(s => s.IsDeleted == false), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null || enrollment.IsDeleted)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollment.Find(id);
            enrollment.IsDeleted = true;
            db.Entry(enrollment).State = EntityState.Modified;
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
