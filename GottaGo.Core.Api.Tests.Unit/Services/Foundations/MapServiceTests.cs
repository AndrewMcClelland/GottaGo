// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Services.Foundations.Maps;
using Moq;
using Tynamix.ObjectFiller;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        private readonly Mock<IMapApiBroker> mapApiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IMapService mapService;

        public MapServiceTests()
        {
            this.mapApiBrokerMock = new Mock<IMapApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.mapService = new MapService(
                mapApiBroker: this.mapApiBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static ExternalMapSearchResponse CreateRandomExternalMapSearchResponse() =>
            CreateRandomExternalMapSearchResponseFiller().Create();

        private static Filler<ExternalMapSearchResponse> CreateRandomExternalMapSearchResponseFiller()
        {
            var filler = new Filler<ExternalMapSearchResponse>();

            filler.Setup()
                .OnType<DateTimeOffset?>().Use(GetRandomDateTimeOffset());

            return filler;
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();


        private static int GetRandomNumber(int min = 1, int max = 10) =>
            new IntRange(min, max + 1).GetValue();
    }
}
