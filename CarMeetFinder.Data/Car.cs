using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Data
{
   public class Car
    {
        [Key]
        public int CarID { get; set; }
        public string Specifications { get; set; }
        public string Description { get; set; }
        public Guid OwnerID { get; set; }
    }
}
