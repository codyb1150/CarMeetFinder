using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models
{
    public class CarListItem
    {
        [Display(Name = "Car ID")]
        public int CarID { get; set; }
        public string Make { get; set; }
        public string VehicleModel { get; set; }
        public string Specifications { get; set; }
        public string Description { get; set; }
    }
}
