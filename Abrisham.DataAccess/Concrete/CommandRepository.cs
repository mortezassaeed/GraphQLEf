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
    public class CommandRepository : IRepository<Command>
    {
        private readonly IDbContextFactory<AbrishamDbContext> _dbFactory;
        public CommandRepository(IDbContextFactory<AbrishamDbContext> dbFactory) =>
            _dbFactory = dbFactory;

        public async Task<Command> CreateAsync(Command entity)
        {
            var currentDbContext = _dbFactory.CreateDbContext();
            currentDbContext.Commands.Add(entity);
            await currentDbContext.SaveChangesAsync();

            return entity;
        }

        public IQueryable<Command> Get() =>
            _dbFactory.CreateDbContext().Set<Command>();
    }
}
