using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Abstract;

namespace SearchProto.Models.Database
{
    public class ProfileDAL : IProfileDAL
    {
        SearchProtoDataContext _ctx = new SearchProtoDataContext();
        
        public IQueryable<Entities.Profile> Profiles
        {
            get { return  _ctx.Profiles.AsQueryable();  }
        }
    }
}