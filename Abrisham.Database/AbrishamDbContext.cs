using Abrisham.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Database
{
    public class AbrishamDbContext : DbContext
    {
        //public AbrishamDbContext() { }

        public AbrishamDbContext(DbContextOptions<AbrishamDbContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
        //{
        //    var conf = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = conf.GetConnectionString("Abrisham");

        //    optionsBuilder.UseSqlServer(connectionString);

        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Result> Results { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Platform>()
                .HasMany(m => m.Commands)
                .WithOne(m => m.Platform)
                .HasForeignKey(m => m.PlatformId);

            modelBuilder.Entity<Command>()
                .HasOne(m => m.Platform)
                .WithMany(m => m.Commands)
                .HasForeignKey(m => m.PlatformId);  

            modelBuilder.Entity<Command>()
            .HasMany(m => m.Results)
            .WithOne(m => m.Command)
            .HasForeignKey(m => m.CommandId);

            modelBuilder.Entity<Result>()
            .HasOne(m => m.Command)
            .WithMany(m => m.Results)
            .HasForeignKey(m => m.CommandId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
