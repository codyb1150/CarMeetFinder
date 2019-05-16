using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.MeetModels
{
    public class MeetEdit
    {
        public int MeetID { get; set; }
        [Display(Name = "Location Of Meet")]
        public string LocationOfMeet { get; set; }

        [Display(Name = "Description Of Meet")]
        public string DescriptionOfMeet { get; set; }

        [Display(Name = "Going?")]
        public bool IsGoing { get; set; }

        [Display(Name = "Date Of Meet")]
        public string DateOfMeet { get; set; }
    }
}
