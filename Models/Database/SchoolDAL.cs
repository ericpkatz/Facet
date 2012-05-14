using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Abstract;

namespace SearchProto.Models.Database
{
    public class SchoolDAL : ISchoolDAL
    {
        SearchProtoDataContext _ctx = new SearchProtoDataContext();
        
        public IQueryable<Entities.School> Schools
        {
            get { return  _ctx.Schools;  }
        }
    }
}