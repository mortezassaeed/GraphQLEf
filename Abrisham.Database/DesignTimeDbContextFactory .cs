using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AbrishamDbContext>
    {
        public AbrishamDbContext CreateDbContext(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = conf.GetConnectionString("Abrisham");
            var builder = new DbContextOptionsBuilder<AbrishamDbContext>();
            builder.UseSqlServer(connectionString);
            return new AbrishamDbContext(builder.Options);
        }
    }
}
