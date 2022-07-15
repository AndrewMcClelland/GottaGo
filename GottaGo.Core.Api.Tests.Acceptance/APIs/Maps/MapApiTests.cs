// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using GottaGo.Core.Api.Tests.Acceptance.Brokers;
using GottaGo.Core.Api.Tests.Acceptance.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Tests.Acceptance.Models.Maps;
using Tynamix.ObjectFiller;
using WireMock.Server;
using Xunit;

namespace GottaGo.Core.Api.Tests.Acceptance.APIs.Maps
{
    [Collection(nameof(ApiTestCollection))]
    public partial class MapApiTests
    {
        private readonly GottaGoCoreApiBroker gottaGoCoreApiBroker;
        private readonly WireMockServer wireMockServer;

        public MapApiTests(GottaGoCoreApiBroker gottaGoCoreApiBroker)
        {
            this.gottaGoCoreApiBroker = gottaGoCoreApiBroker;
            this.wireMockServer = WireMockServer.Start(9999);
        }

        private static ExternalMapSearchResponse CreateRandomExternalMapSearchResponse() =>
            CreateRandomExternalMapSearchResponseFiller().Create();

        private static AddressSearch CreateRandomAddressSearch() =>
            CreateRandomAddressSearchFiller().Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<ExternalMapSearchResponse> CreateRandomExternalMapSearchResponseFiller()
        {
            var filler = new Filler<ExternalMapSearchResponse>();

            filler.Setup()
                .OnType<DateTimeOffset?>().Use(GetRandomDateTimeOffset());

            return filler;
        }

        private static Filler<AddressSearch> CreateRandomAddressSearchFiller() =>
            new Filler<AddressSearch>();
    }
}
