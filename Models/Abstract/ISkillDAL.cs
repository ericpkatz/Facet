using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Entities;

namespace SearchProto.Models.Abstract
{
    public interface ISkillDAL
    {
        IQueryable<Skill> Skills { get; }
    }
}