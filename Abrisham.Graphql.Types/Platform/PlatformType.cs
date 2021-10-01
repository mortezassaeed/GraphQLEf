using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abrisham.Common.Models;
using Abrisham.Database;
using HotChocolate;

namespace Abrisham.Graphql.Types.Platform
{
    public class PlatformType : ObjectType<Abrisham.Common.Models.Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Common.Models.Platform> descriptor)
        {
            descriptor.Description("this entity is for store your platfrom infortamtion");

            descriptor
                .Field(m => m.LicenseKey).Ignore();

            descriptor
                .Field(m => m.Commands)
                //.ResolveWith<Resolvers>(p => p.GetCommand(default!, default!))
                .Resolve(() =>  new List<Command>() { new Command() { HowTo = "aa" , Id = 1 , CommandLine = "sdsd", PlatformId = 1  } }  )
              
                .Description("this is the list of avalible commands for this platform");

            base.Configure(descriptor);
        }
         
        private class Resolvers { 
            public IQueryable<Command> GetCommand(Abrisham.Common.Models.Platform platform, [ScopedService] AbrishamDbContext context)
                => context.Commands.Where(c => c.PlatformId == platform.Id);    
        }

    }
}
