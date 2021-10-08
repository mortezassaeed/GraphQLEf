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
using Abrisham.Common.Models;

namespace Abrisham.Graphql.Types.Platform
{


    public class Resolvers
    {
        IRepository<Command> _commandrepository;
        ILogger<Resolvers> _logger;
        public Resolvers(IRepository<Command> commandrepository, ILogger<Resolvers> logger)
        {
            _commandrepository = commandrepository;
            _logger = logger;
        }

        public IQueryable<Command> GetCommands([Parent]Abrisham.Common.Models.Platform platform , [Service] IRepository<Command> commandRepo1)
        {
            return commandRepo1.Get().Where(m => m.PlatformId == platform.Id);
        }

    }

    public class PlatformType : ObjectType<Abrisham.Common.Models.Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Common.Models.Platform> descriptor)
        {
            descriptor.Description("this entity is for store your platfrom infortamtion");

            descriptor
                .Field(m => m.LicenseKey).Ignore();

            descriptor
                .Field(m => m.Commands)
                .Type<HotChocolate.Types.ListType<CommandType>>()
                //.ResolveWith<Resolvers>(p => p.GetCommands(default!,default!))
                .Description("this is the list of avalible commands for this platform");

            base.Configure(descriptor);
        }

        
    }
}
