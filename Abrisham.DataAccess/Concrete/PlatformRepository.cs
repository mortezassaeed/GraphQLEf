using Abrisham.Common.Models;
using Abrisham.DataAccess.Interface;
using Abrisham.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.DataAccess.Concrete
{
    public class PlatformRepository : IRepository<Platform>
    {
        private readonly IDbContextFactory<AbrishamDbContext> _dbFactory;
        public PlatformRepository(IDbContextFactory<AbrishamDbContext> dbFactory)
            => _dbFactory = dbFactory;

        public async Task<Platform> CreateAsync(Platform entity)
        {
            var currentDbContext = _dbFactory.CreateDbContext();
            currentDbContext.Platforms.Add(entity);
            await currentDbContext.SaveChangesAsync();

            return entity;
        }

        public IQueryable<Platform> Get()
            => _dbFactory.CreateDbContext().Platforms;
    }
}
