using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abrisham.Common.Models;
using Abrisham.Database;
using HotChocolate;
using Abrisham.DataAccess.Concrete;
using Abrisham.DataAccess.Interface;
using Microsoft.Extensions.Logging;

namespace Abrisham.Graphql.Types.Platform
{
    public class ResultType : ObjectType<Abrisham.Common.Models.Result>
    {
        private class Resolvers
        {
            IRepository<Result> _commandrepository;
            ILogger<Resolvers> _logger;
            public Resolvers(IRepository<Result> commandrepository, ILogger<Resolvers> logger)
            {
                _commandrepository = commandrepository;
                _logger = logger;
            }
        }
        protected override void Configure(IObjectTypeDescriptor<Common.Models.Result> descriptor)
        {
            descriptor
                .Field(m => m.Command)
                .Type<NonNullType<CommandType>>()
                 //.ResolveWith<Resolvers>(p => p.GetCommands(default!,default!))
                .Description("this is the list of avalible commands for this platform");

            descriptor
                .Field(m => m.Type)
                .Type<HotChocolate.Types.EnumType<CommandResultType>>();

            base.Configure(descriptor);
        }


    }
}
