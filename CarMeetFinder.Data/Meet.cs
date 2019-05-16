using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Data
{
    public class Meet
    {
        [Key]
        public int MeetID { get; set; }
        public Guid OwnerID { get; set; }
        public string LocationOfMeet { get; set; }
        public string DescriptionOfMeet { get; set; }
        public string DateOfMeet { get; set; }

        [DefaultValue(false)]
        public bool IsGoing { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        
    }
}

