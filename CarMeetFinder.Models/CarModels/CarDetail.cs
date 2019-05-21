using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models
{
    public class CarDetail
    {
        [Display(Name = "Car ID")]
        public int CarID { get; set; }
        public string Make { get; set; }

        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }
        public string Specifications { get; set; }

        [Display(Name = "About The Car")]
        public string Description { get; set; }
        public string CarCombine { get; set; }

        [Display(Name = "Member Info.")]
        public string DisplayName { get; set; }


    }
}
