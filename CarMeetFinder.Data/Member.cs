using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Data
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Location { get; set; }
        public Guid OwnerID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
