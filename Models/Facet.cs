using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacetSearch.Models
{
    public class Facet
    {
        public int Index { get; set; }

        public string Name { get; set; }

        private List<FacetItem> _facetItems;

        public List<FacetItem> FacetItems
        {
            get { return _facetItems = (_facetItems ?? new List<FacetItem>()); }
            set { _facetItems = value; }
        }

        public Func<string, List<int>, List<FacetSuggestion>> SuggestionFunction { get; set; }

        public Func<int, string> LabelFunction { get; set; }

        public bool IssueUpdate { get; set; }

        public bool HasMustHaves
        {
            get { return MustHaves.Count > 0; }
        }
        public List<int> MustHaves
        {
            get { return FacetItems.Where(item => item.Mandatory).Select(item => item.Id).ToList(); }
        }

        public List<int> Pluses
        {
            get { return FacetItems.Where(item => !item.Mandatory).Select(item => item.Id).ToList(); }
        }

        public List<int> Ids
        {
            get { return FacetItems.Select(item => item.Id).ToList(); }
        }

        public string Color
        {
            get { return this.Colors[this.Index]; }
        }

        private List<String> Colors = new List<string> { "#F2E4C4", "#F4B392", "#C4513C" };
    }
}