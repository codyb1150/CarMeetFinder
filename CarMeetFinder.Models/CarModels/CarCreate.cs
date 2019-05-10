using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models
{
    public class CarCreate
    {
        public string Make { get; set; }

        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }
        public string Specifications { get; set; }

        [Display(Name = "About The Car")]
        public string Description { get; set; }

        [Display(Name = "Whos Car Does This Belong To?")]
        public int MemberID { get; set; }
    }
}
