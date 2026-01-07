using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.Entities;
using System.Collections.Generic;

namespace StudentRegistration.Data.DbContext
{
    public partial class SchoolDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=SchoolDB;Trusted_Connection=True;");
            }
        }
    }
}
