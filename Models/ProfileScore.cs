using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Entities;

namespace FacetSearch.Models
{
    public class ProfileScore
    {
        public Profile Profile { get; set; }
        public int Score { get; set; }
    }
}