using System.Collections.Generic;
using System.Web.Mvc;
using FacetSearch.Models;
using SearchProto.Models;
using SearchProto.Models.Entities;
using SearchProto.Models.Services;
using System.Linq;


namespace SearchProto.Controllers
{
    public class HomeController : Controller
    {
        SearchProtoService svc = new SearchProtoService();

        public HomeController()
        {

        }

        public ViewResult Index()
        {
            return View(FacetSearchComposite());
        }

        private FacetSearchComposite<ProfileScore> FacetSearchComposite()
        {
            var facets = GetFacets();
            var schoolFacet = facets.Where(f => f.Name == "Schools").Single();
            var skillFacet = facets.Where(f => f.Name == "Skills").Single();
            var companyFacet = facets.Where(f => f.Name == "Companies").Single();
            var schoolIds = schoolFacet.MustHaves;
            var optionalSchoolIds = schoolFacet.Pluses;
            var companyIds = companyFacet.MustHaves;
            var optionalCompanyIds = companyFacet.Pluses;
            var skillIds = skillFacet.MustHaves;
            var optionalSkillIds = skillFacet.Pluses;
            var composite = new FacetSearchComposite<ProfileScore>()
                                {
                                    Facets = GetFacets(),
                                    ResultFunction = (f) => (from profile in svc.Profiles
                                                             where
                                                                 (
                                                                     (schoolIds.Count == 0 ||
                                                                      !schoolIds.Except(
                                                                          profile.Schools.Select(s => s.SchoolID)).Any())
                                                                     &&
                                                                     (companyIds.Count == 0 ||
                                                                      !companyIds.Except(
                                                                          profile.Companies.Select(s => s.CompanyId)
                                                                           ).Any())
                                                                     &&
                                                                     (skillIds.Count == 0 ||
                                                                      !skillIds.Except(
                                                                          profile.Skills.Select(s => s.SkillID)
                                                                           ).Any())
                                                                 )
                                                             select new ProfileScore
                                                                        {
                                                                            Profile = profile,
                                                                            Score =
                                                                                optionalSkillIds.Count -
                                                                                optionalSkillIds.Except(
                                                                                    profile.Skills.Select(
                                                                                        ps => ps.SkillID)).Count()
                                                                                        +
                                                                                                                                                                                                                        optionalSchoolIds.Count -
                                                                                optionalSchoolIds.Except(
                                                                                    profile.Schools.Select(
                                                                                        ps => ps.SchoolID)).Count()
                                                                                        +
                                                                                optionalCompanyIds.Count -
                                                                                optionalCompanyIds.Except(
                                                                                    profile.Companies.Select(
                                                                                        ps => ps.CompanyId)).Count()
                                                                        }).ToList().OrderByDescending(ps => ps.Score).
                                                                ToList()
            };
            return composite;
        }

        private List<Facet> GetFacets()
        {
            var facets= (List<Facet>)Session["facets"];
            if(facets == null)
            {
                facets = new List<Facet>
                {

                                                   new Facet {Name = "Skills", Index = 0, LabelFunction = (id)=>svc.Skills.Where(item=>item.SkillID == id).Single().Name, SuggestionFunction = (term, resultIds)=> svc.Profiles.Where(p=>resultIds.Contains(p.ProfileID)).SelectMany(p=>p.Skills).Select(ps=>ps.Skill).Distinct().Where(sk=>sk.Name.Contains(term)).Select(sk=>new FacetSuggestion{Id = sk.SkillID, Label = sk.Name}).ToList() },
                                                   new Facet {Name = "Schools", Index = 1, LabelFunction = (id)=>svc.Schools.Where(item=>item.SchoolID == id).Single().Name, SuggestionFunction = (term,resultIds)=>  svc.Profiles.Where(p=>resultIds.Contains(p.ProfileID)).SelectMany(p=>p.Schools).Select(ps=>ps.School).Distinct().Where(sk=>sk.Name.Contains(term)).Select(sk=>new FacetSuggestion{Id = sk.SchoolID, Label = sk.Name}).ToList()},
                                                   new Facet{Name = "Companies", Index = 2, LabelFunction= (id)=>svc.Companies.Where(item=>item.CompanyID == id).Single().Name, SuggestionFunction = (term, resultIds)=>  svc.Profiles.Where(p=>resultIds.Contains(p.ProfileID)).SelectMany(p=>p.Companies).Select(ps=>ps.Company).Distinct().Where(sk=>sk.Name.Contains(term)).Select(sk=>new FacetSuggestion{Id = sk.CompanyID, Label = sk.Name}).ToList()}

                };
                Session["facets"] = facets;
            }
            return facets;
        }


        public ActionResult Facet(int? id, Facet facet, FacetActions facetAction, int? facetItemIndex )
        {
            switch (facetAction)
            {
                case FacetActions.Add:

                    var facetItem = new FacetItem {Id = id.Value, Label = GetFacets()[facet.Index].LabelFunction(id.Value)};
                    facet.FacetItems.Add(facetItem);
                    break;
                case FacetActions.Remove:
                    facet.FacetItems.RemoveAt(facetItemIndex.Value);
                    break;
                case FacetActions.ToggleMandatory:
                    facet.FacetItems[facetItemIndex.Value].Mandatory =
                        !facet.FacetItems[facetItemIndex.Value].Mandatory;
                    break;
            }
            GetFacets()[facet.Index].FacetItems = facet.FacetItems;
            GetFacets()[facet.Index].IssueUpdate = true;
            GetFacets().Where(f=>f.Index != facet.Index).ToList().ForEach(f=>f.IssueUpdate = false);
            facet.IssueUpdate = true;
            return View(facet);
        }

        public ActionResult Results()
        {
            return View(FacetSearchComposite());
        }

        public JsonResult Suggest(string term, int index)
        {
            var facet = GetFacets()[index];
            var resultIds = FacetSearchComposite().Results.Select(p => p.Profile.ProfileID).ToList();
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = facet.SuggestionFunction(term, resultIds).Where(st=> !facet.Ids.Contains(st.Id)).Select(fs=> new{id = fs.Id, label=fs.Label})
            };
        }


    }
}
