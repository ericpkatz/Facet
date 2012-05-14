using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacetSearch.Models
{
    public class FacetItem : FacetSuggestion
    {

        private bool _mandatory = true;
        public bool Mandatory
        {
            get { return _mandatory; }
            set { _mandatory = value; }
        }
    }
}