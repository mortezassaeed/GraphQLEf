using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Graphql.Types.Platform
{
    public record ResultInput(Abrisham.Common.Models.CommandResultType Type,string Message, int CommandId);
}
