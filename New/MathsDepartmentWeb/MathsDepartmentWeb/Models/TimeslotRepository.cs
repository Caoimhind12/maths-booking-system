using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsDepartmentWeb.Models
{
    public class TimeslotRepository
    {
        MathsDepartmentDBEntities db = new MathsDepartmentDBEntities();

        public List<Timeslot> GetAllTimeslots()
        {
            return db.Timeslots.ToList();
        }
    }
}