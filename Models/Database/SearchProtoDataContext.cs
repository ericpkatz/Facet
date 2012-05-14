using System.Data.Entity;
using SearchProto.Models.Entities;

namespace SearchProto.Models.Database
{
    public class SearchProtoDataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}