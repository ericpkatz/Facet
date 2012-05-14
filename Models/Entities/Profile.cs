using System.Collections;
using System.Collections.Generic;

namespace SearchProto.Models.Entities
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public  string Name { get; set; }

        public virtual ICollection<ProfileCompany> Companies { get; set; }
        public virtual ICollection<ProfileSchool> Schools { get; set; }
        public virtual ICollection<ProfileSkill> Skills { get; set; }
    }
}