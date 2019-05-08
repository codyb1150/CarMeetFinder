using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models.MemberModels
{
    public class MemberCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
    }
}
