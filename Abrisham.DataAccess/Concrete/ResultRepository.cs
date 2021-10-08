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
    public class ResultRepository : IRepository<Result>
    {
        private readonly IDbContextFactory<AbrishamDbContext> _dbFactory;
        public ResultRepository(IDbContextFactory<AbrishamDbContext> dbFactory) =>
            _dbFactory = dbFactory;

        public async Task<Result> CreateAsync(Result entity)
        {
            var currentDbContext = _dbFactory.CreateDbContext();
            currentDbContext.Results.Add(entity);
            await currentDbContext.SaveChangesAsync();

            return entity;
        }

        public IQueryable<Result> Get() => 
            _dbFactory.CreateDbContext().Set<Result>();
    }
}
