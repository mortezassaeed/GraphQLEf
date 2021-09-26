using Abrisham.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Database
{
    public class AbrishamDbContext : DbContext
    {
        public AbrishamDbContext() { }

        public AbrishamDbContext(DbContextOptions<AbrishamDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = conf.GetConnectionString("Abrisham");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
