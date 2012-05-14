using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchProto.Models.Abstract;
using SearchProto.Models.Database;
using SearchProto.Models.Entities;

namespace SearchProto.Models.Services
{
    public class SearchProtoService
    {
        private IProfileDAL _profileDAL;
        private ISkillDAL _skillDAL;
        private ISchoolDAL _schoolDAL;
        private ICompanyDAL _companyDAL;

        public SearchProtoService(IProfileDAL profileDal, ISkillDAL skillDal, ISchoolDAL schoolDal, ICompanyDAL companyDal)
        {
            _profileDAL = profileDal;
            _skillDAL = skillDal;
            _schoolDAL = schoolDal;
            _companyDAL = companyDal;
        }

        public SearchProtoService() : this(new ProfileDAL(), new SkillDAL(), new SchoolDAL(), new CompanyDAL())
        {
            
        }

        public IQueryable<Skill> Skills
        {
            get { return _skillDAL.Skills; }
        }

        public IQueryable<School> Schools
        {
            get { return _schoolDAL.Schools; }
        }

        public IQueryable<Company> Companies
        {
            get { return _companyDAL.Companies; }
        }

        public IQueryable<Profile> Profiles
        {
            get { return _profileDAL.Profiles; }
        }
    }
}