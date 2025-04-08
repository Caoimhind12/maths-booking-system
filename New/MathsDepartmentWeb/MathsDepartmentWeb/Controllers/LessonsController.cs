using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MathsDepartmentWeb.Models;

namespace MathsDepartmentWeb.Controllers
{
    public class LessonsController : Controller
    {
        private MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Day).Include(l => l.Teacher).Include(l => l.Timeslot);
            return View(lessons.ToList());
        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.DayID = new SelectList(db.Days, "DayID", "Days");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "Forename");
            ViewBag.TimeslotID = new SelectList(db.Timeslots, "TimeslotID", "Timeslots");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonID,TeacherID,TimeslotID,DayID,Available,SpotsTaken,Subject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DayID = new SelectList(db.Days, "DayID", "Days", lesson.DayID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "Forename", lesson.TeacherID);
            ViewBag.TimeslotID = new SelectList(db.Timeslots, "TimeslotID", "Timeslots", lesson.TimeslotID);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayID = new SelectList(db.Days, "DayID", "Days", lesson.DayID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "Forename", lesson.TeacherID);
            ViewBag.TimeslotID = new SelectList(db.Timeslots, "TimeslotID", "Timeslots", lesson.TimeslotID);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonID,TeacherID,TimeslotID,DayID,Available,SpotsTaken,Subject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayID = new SelectList(db.Days, "DayID", "Days", lesson.DayID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "Forename", lesson.TeacherID);
            ViewBag.TimeslotID = new SelectList(db.Timeslots, "TimeslotID", "Timeslots", lesson.TimeslotID);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
