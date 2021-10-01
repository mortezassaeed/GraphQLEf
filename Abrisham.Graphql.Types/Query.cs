using Abrisham.Database;
using Abrisham.Common.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Graphql.Types
{
    public class Query
    {
        [UseDbContext(typeof(AbrishamDbContext))]
        [UseProjection]
        public IQueryable<Abrisham.Common.Models.Platform> GetPlatform([ScopedService] AbrishamDbContext context){
            return context.Platforms;
        }

        [UseDbContext(typeof(AbrishamDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AbrishamDbContext context)
        {
            return context.Commands;
        }
    }
}
