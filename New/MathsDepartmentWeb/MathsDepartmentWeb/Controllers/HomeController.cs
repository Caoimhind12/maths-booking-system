using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathsDepartmentWeb.Models;

namespace MathsDepartmentWeb.Controllers
{
    public class HomeController : Controller
    {
        private MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();
        public ActionResult Index(int Id)
        {
            TeacherRepository teachersrep = new TeacherRepository();


            var allteachers = teachersrep.GetAllTeachers().Where(k => k.TeacherID != Id).OrderBy(k => k.FullName);


            if (allteachers.Count() > 0)
            {
                ViewData["AllTeachers"] = allteachers;
            }

            var teacheremail = teachersrep.GetAllTeachers().Where(k => k.TeacherID == Id);
            if (teacheremail.Count() > 0)
            {
                ViewData["TeacherEmail"] = teacheremail;
            }

            var teachertelnum = teachersrep.GetAllTeachers().Where(k => k.TeacherID == Id);
            if (teachertelnum.Count() > 0)
            {
                ViewData["TeacherTelNum"] = teachertelnum;
            }

            var teacherroom = teachersrep.GetAllTeachers().Where(k => k.TeacherID == Id);
            if (teacherroom.Count() > 0)
            {
                ViewData["TeacherRoom"] = teacheremail;
            }

            var teacher = teachersrep.GetAllTeachers().Where(k => k.TeacherID == Id).FirstOrDefault();
            if (teacher != null)
            {
                LessonRepository lessonrep = new LessonRepository();
                var teacherlessons = lessonrep.GetAllLesson().Where(t => t.TeacherID == Id).OrderBy(t => t.DayID).ThenBy(t => t.TimeslotID).ThenBy(t => t.Name);
                var Availablelessons = teacherlessons.Where(t => t.Available == true);
                if (Availablelessons.Count() > 0)
                {
                    ViewData["TeacherSchedule"] = teacherlessons;
                }


                return View(teacher);
            }
            else
            {
                return Redirect("/");
            }
        }

        public ActionResult Add()
        {
            List<SelectListItem> teacherList = new List<SelectListItem>();
            TeacherRepository teachersrep = new TeacherRepository();
            var myteachers = teachersrep.GetAllTeachers().OrderBy(k => k.FullName);
            if (myteachers.Count() > 0)
            {
                foreach (Teacher t in myteachers)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = t.TeacherID.ToString();
                    sli.Text = t.FullName;
                    teacherList.Add(sli);
                }
            }
            ViewData["Teachers"] = teacherList;

            return View();
        }

        public ActionResult All()
        {
            TeacherRepository teachersrep = new TeacherRepository();
            var myteachers = teachersrep.GetAllTeachers();

            if (myteachers.Count() > 0)
            {
                ViewData["Teachers"] = myteachers.OrderBy(k => k.FullName);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your timeslot page.";

            LessonRepository lessonrep = new LessonRepository();
            var mylessons = lessonrep.GetAllLesson().Where(t => t.Available == true).OrderBy(t => t.DayID).ThenBy(t => t.TimeslotID).ThenBy(t => t.Name);
            if (mylessons.Count() > 0)
            {
                ViewData["MyLessons"] = mylessons;
            }
            return View();
        }
    }
}