using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsDepartmentWeb.Models
{
    public class LessonRepository
    {
        MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();


        public List<Lesson> GetAllLesson()
        {
            return db.Lessons.ToList();
        }

    }
}