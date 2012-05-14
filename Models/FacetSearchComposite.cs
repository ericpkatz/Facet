using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacetSearch.Models
{
    public class FacetSearchComposite<T>
    {
        private List<Facet> _facets;
        
        public List<Facet> Facets
        {
            get { return _facets = (_facets ?? new List<Facet>()); }
            set { _facets = value; }
        }

        public Func<List<Facet>, List<T>> ResultFunction { get; set; }

        public List<T> Results
        {
            get { return ResultFunction(this.Facets); }
        }
    }
}