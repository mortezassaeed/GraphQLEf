using Abrisham.DataAccess.Concrete;
using Abrisham.DataAccess.Interface;
using Abrisham.Graphql.Types.Platform;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Graphql.Types
{
    public class Mutation
    {
        public async Task<Abrisham.Graphql.Types.Platform.AddPlatformPayload> AddPlatfromAsync(PlatformInput input
        , [Service] IRepository<Abrisham.Common.Models.Platform> platformRepository)
        {
            var platform = new Abrisham.Common.Models.Platform()
            {
                Name = input.Name
            };
            var newPlatform = await platformRepository.CreateAsync(platform);

           return new Abrisham.Graphql.Types.Platform.AddPlatformPayload(newPlatform);
        }

        public async Task<Abrisham.Graphql.Types.Platform.AddResultPayload> AddResultAsync(ResultInput input
        , [Service] IRepository<Abrisham.Common.Models.Result> platformRepository)
        {
            var result = new Abrisham.Common.Models.Result()
            {
                CommandId = input.CommandId,
                Type = input.Type,
                Message = input.Message
            };
            var newReuslt = await platformRepository.CreateAsync(result);

            return new Abrisham.Graphql.Types.Platform.AddResultPayload(newReuslt);
        }

    }
}
