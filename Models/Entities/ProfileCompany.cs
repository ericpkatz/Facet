using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchProto.Models.Entities
{
    public class ProfileCompany
    {
        public int ProfileCompanyId { get; set; }
        
        public int ProfileId { get; set; }
        public int CompanyId { get; set; }

        public int Year { get; set; }

        public Profile Profile { get; set; }
        public virtual Company Company { get; set; }
    }
}