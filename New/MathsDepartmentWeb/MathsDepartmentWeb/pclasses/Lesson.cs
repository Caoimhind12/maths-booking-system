using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsDepartmentWeb.Models
{
    public partial class Lesson
    {
        TeacherRepository teachersrep = new TeacherRepository();
        DayRepository dayrep = new DayRepository();
        TimeslotRepository timeslotrep = new TimeslotRepository();

        public string Name
        {
            get
            {
                return teachersrep.GetAllTeachers().Where(k => k.TeacherID == this.TeacherID).FirstOrDefault().FullName;
            }
        }

        public string DayName
        {
            get
            {
                return dayrep.GetAllDays().Where(k => k.DayID == this.DayID).FirstOrDefault().Days;
            }
        }

        public string TimeslotName
        {
            get
            {
                return timeslotrep.GetAllTimeslots().Where(k => k.TimeslotID == this.TimeslotID).FirstOrDefault().Timeslots;
            }
        }
    
    }
}