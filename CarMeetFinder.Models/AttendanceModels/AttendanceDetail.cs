using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.AttendanceModels
{
    public class AttendanceDetail
    {
        [Display(Name = "Attendance ID")]
        public int AttendanceID { get; set; }

        [Display(Name = "Meet ID")]
        public int MeetID { get; set; }

        [Display(Name = "Car ID")]
        public int CarID { get; set; }
    }
}
