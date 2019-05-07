﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Models
{
    public class CarCreate
    {
        [Display(Name = "Car Specs")]
        public string Specifications { get; set; }

        [Display(Name = "About The Car")]
        public string Description { get; set; }
    }
}
