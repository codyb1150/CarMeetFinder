using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.MemberModels
{
    public class MemberListItem
    {
        [Display(Name = "Member ID")]
        public int MemberID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name") ]
        public string FullName { get; set; }
        public string Location { get; set; }
    }
}
