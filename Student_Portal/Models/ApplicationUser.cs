﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public Boolean AdminApproved { get; set; }
        public string IDNumber { get; set; }
    }
}