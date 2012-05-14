using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Abstract;

namespace SearchProto.Models.Database
{
    public class CompanyDAL : ICompanyDAL
    {
        SearchProtoDataContext _ctx = new SearchProtoDataContext();
        
        public IQueryable<Entities.Company> Companies
        {
            get { return  _ctx.Companies.AsQueryable();  }
        }
    }
}