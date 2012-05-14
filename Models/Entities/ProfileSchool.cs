using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchProto.Models.Entities
{
    public class ProfileSchool
    {
        public int ProfileSchoolID { get; set; }
        
        public int ProfileID { get; set; }
        public int SchoolID { get; set; }

        public int YearGraduated { get; set; }

        public Profile Profile { get; set; }
        public virtual School School { get; set; }
    }
}