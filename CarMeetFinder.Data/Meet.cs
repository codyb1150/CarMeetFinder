﻿using System;
using System.Collections.Generic;
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
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
