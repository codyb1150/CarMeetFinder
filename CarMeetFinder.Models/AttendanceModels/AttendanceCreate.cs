using CarMeetFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.AttendanceModels
{
   public class AttendanceCreate
    {
        [Display(Name = "Attendance ID")]
        public int AttendanceID { get; set; }

        [Display(Name = "Meet ID")]
        public int MeetID { get; set; }

        [Display(Name = "Member ID")]
        public int MemberID { get; set; }

        [Display(Name = "Car ID")]
        public int CarID { get; set; }

        public Member Member { get; set; }
        public Car Car { get; set; }
    }
}
