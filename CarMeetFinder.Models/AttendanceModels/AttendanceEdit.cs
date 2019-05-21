using CarMeetFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.AttendanceModels
{
    public class AttendanceEdit
    {
        [Display(Name = "Attendance ID")]
        public int AttendanceID { get; set; }

        [Display(Name = "Meet Location")]
        public int MeetID { get; set; }

        [Display(Name = "Car")]
        public int CarID { get; set; }

        public Member Member { get; set; }
        public Car Car { get; set; }
    }
}
