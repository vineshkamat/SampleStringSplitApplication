using CodeFirstStoreFunctions;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SampleStringSplitApplication
{
    public partial class TestModel : DbContext
    {
        public TestModel()
            : base("name=TestModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention<DbContext>("dbo"));
            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
    }
}
