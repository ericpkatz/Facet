using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SearchProto.Models.Entities;

namespace SearchProto.Models.Database
{
    public class SearchProtoInitializer : DropCreateDatabaseAlways<SearchProtoDataContext>
    {
        protected override void Seed(SearchProtoDataContext context)
        {
            //base.Seed(context);
            var mit = new School {Name = "MIT"};
            var harvard = new School {Name = "Harvard"};
            var yale = new School {Name = "Yale"};
            var nyu = new School { Name = "NYU" };
            var schools = new List<School>
                              {
                                  mit,
                                  harvard,
                                  yale,
                                  nyu
                              };
            foreach (var school in schools)
                context.Schools.Add(school);

            var ibm = new Company {Name = "IBM"};
            var google = new Company {Name = "Google"};
            var onewire = new Company {Name = "OneWire"};
            var amazon = new Company {Name = "Amazon"};
            var schoolNet = new Company { Name = "SchoolNet" };
            var nbc = new Company { Name = "NBC" };

            var companies = new List<Company>
                                {
                                    ibm,
                                    google,
                                    onewire,
                                    amazon
                                };

            foreach (var company in companies)
                context.Companies.Add(company);
            var acting = new Skill {Name = "Acting"};
            var cooking = new Skill {Name = "Cooking"};
            var skiing = new Skill {Name = "Skiiing"};
            var boxing = new Skill {Name = "Boxing"};
            var skills = new List<Skill>
                             {
                                 acting, cooking, skiing, boxing
                             };

            foreach (var skill in skills)
                context.Skills.Add(skill);

            var user = new Profile {Name = "Eric"};
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill {Skill = boxing});
            user.Skills.Add(new ProfileSkill { Skill = cooking });

            user.Schools = new List<ProfileSchool>();
            user.Schools.Add(new ProfileSchool {School = mit});
            user.Schools.Add(new ProfileSchool { School = nyu });

            user.Companies = new List<ProfileCompany>();
            user.Companies.Add(new ProfileCompany {Company = onewire});
            user.Companies.Add(new ProfileCompany { Company = schoolNet });
            context.Profiles.Add(user);

            user = new Profile { Name = "Alec Baldwin" };
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill { Skill = acting });

            user.Schools = new List<ProfileSchool>();
            user.Schools.Add(new ProfileSchool { School = yale});
            user.Schools.Add(new ProfileSchool { School = harvard });

            user.Companies = new List<ProfileCompany>();
            user.Companies.Add(new ProfileCompany { Company = nbc });
            context.Profiles.Add(user);

            user = new Profile { Name = "Mike Tyson" };
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill { Skill = boxing });

            user.Schools = new List<ProfileSchool>();
            user.Companies = new List<ProfileCompany>();
            user.Companies.Add(new ProfileCompany { Company = nbc });
            context.Profiles.Add(user);


            user = new Profile { Name = "Rosa" };
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill { Skill = cooking });

            user.Schools = new List<ProfileSchool>();
            user.Companies = new List<ProfileCompany>();
            user.Companies.Add(new ProfileCompany { Company = onewire });
            context.Profiles.Add(user);

            user = new Profile { Name = "Mike Spinx" };
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill { Skill = boxing });
            user.Skills.Add(new ProfileSkill { Skill = cooking });

            user.Schools = new List<ProfileSchool>();
            user.Schools.Add(new ProfileSchool { School = yale });
            user.Schools.Add(new ProfileSchool { School = mit });
            context.Profiles.Add(user);

            user = new Profile { Name = "Butch Graves" };
            user.Skills = new List<ProfileSkill>();
            user.Skills.Add(new ProfileSkill { Skill = boxing });

            user.Schools = new List<ProfileSchool>();
            user.Schools.Add(new ProfileSchool { School = yale });
            user.Companies = new List<ProfileCompany>();
            user.Companies.Add(new ProfileCompany { Company = nbc });
            context.Profiles.Add(user);

            context.SaveChanges();
        }
    }
}