using Entities.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class PeopleRegistryDBContext : IdentityDbContext<Person>
    {
        public PeopleRegistryDBContext(DbContextOptions<PeopleRegistryDBContext> options) : base(options)
        {
        }

        public DbSet<Person> Pessoa { get; set; }

        public string ObterStringConexao()
        {
            string strcon = "Data Source=DESKTOP-61L2M0C\\SQLEXPRESS;integrated security=SSPI;initial Catalog=DB_PeopleRegistry_V2";
            return strcon;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //builder.Entity<Person>().ToTable("AspNetUsers").HasKey(x => x.Id);
            modelBuilder.ApplyConfiguration(new PersonMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}