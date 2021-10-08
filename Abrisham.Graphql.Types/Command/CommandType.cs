using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace Abrisham.Graphql.Types.Platform
{
    public class CommandType : ObjectType<Abrisham.Common.Models.Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Common.Models.Command> descriptor)
        {
            descriptor.Description("this entity is for store your platfrom infortamtion");

            descriptor
                .Field(m => m.Platform)
                .Type<NonNullType<ResultType>>();

            descriptor
                .Field(m => m.Results)
                .Type<ListType<ResultType>>();

            base.Configure(descriptor);
        }
    }
}
