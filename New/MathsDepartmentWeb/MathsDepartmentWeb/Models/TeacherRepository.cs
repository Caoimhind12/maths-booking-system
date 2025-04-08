using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsDepartmentWeb.Models
{
    public class TeacherRepository
    {
        MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();

        public List<Teacher> GetAllTeachers()
        {
            return db.Teachers.ToList();
        }
    }
}