using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Abstract;

namespace SearchProto.Models.Database
{
    public class SkillDAL : ISkillDAL
    {
        SearchProtoDataContext _ctx = new SearchProtoDataContext();
        
        public IQueryable<Entities.Skill> Skills
        {
            get { return  _ctx.Skills;  }
        }
    }
}