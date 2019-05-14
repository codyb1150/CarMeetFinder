using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Data
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }
        public Guid OwnerID { get; set; }
        public int CarID { get; set; }
        public int MeetID { get; set; }


        public virtual Car Car { get; set; }
        public virtual Meet Meet { get; set; }
    }
}
