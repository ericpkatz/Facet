using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchProto.Models.Entities
{
    public class ProfileSkill
    {
        public int ProfileSkillID { get; set; }
        
        public int SkillID { get; set; }
        public int ProfileID { get; set; }

        public virtual Skill Skill { get; set; }
        public Profile Profile { get; set; }


    }
}