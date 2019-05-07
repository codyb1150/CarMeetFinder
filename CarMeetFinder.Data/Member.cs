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
        public Guid OwnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
