using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsDepartmentWeb.Models
{
    public class DayRepository
    {
        MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();

        public List<Day> GetAllDays()
        {
            return db.Days.ToList();
        }
    }
}