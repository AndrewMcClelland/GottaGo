// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;
using Xunit;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        [Fact]
        public async Task ShouldSearchAddressAsync()
        {
            // given
            ExternalMapSearchResponse externalMapSearchResponse = CreateRandomExternalMapSearchResponse();

            List<Address> expectedAddressers = externalMapSearchResponse.Responses.Select(response =>
                new Address
                {
                    
                }).ToList();

            // when


            // then
        }
    }
}
