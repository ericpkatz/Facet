using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Entities;

namespace SearchProto.Models.Abstract
{
    public interface ICompanyDAL
    {
        IQueryable<Company> Companies { get; }
    }
}