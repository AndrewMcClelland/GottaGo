// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Linq.Expressions;
using System.Net.Http;
using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Services.Foundations.Maps;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        private readonly Mock<IMapApiBroker> mapApiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IMapService mapService;

        public MapServiceTests()
        {
            this.mapApiBrokerMock = new Mock<IMapApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.compareLogic = new CompareLogic();

            this.mapService = new MapService(
                mapApiBroker: this.mapApiBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        public static TheoryData<Xeption> CriticalDependencyException()
        {
            string someMessage = GetRandomString();
            var someResponseMessage = new HttpResponseMessage();

            return new TheoryData<Xeption>()
            {
                new HttpResponseUrlNotFoundException(someResponseMessage, someMessage),
                new HttpResponseUnauthorizedException(someResponseMessage, someMessage),
                new HttpResponseForbiddenException(someResponseMessage, someMessage)
            };
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedMapDependencyException) =>
            actualException => actualException.SameExceptionAs(expectedMapDependencyException);

        private static ExternalMapSearchResponse CreateRandomExternalMapSearchResponse() =>
            CreateRandomExternalMapSearchResponseFiller().Create();

        private static AddressSearch CreateRandomAddressSearch() =>
            CreateRandomAddressSearchFiller().Create();

        private Expression<Func<ExternalMapSearchParameters, bool>> SameInformationAs(
            ExternalMapSearchParameters expectedExternalMapSearchParameters)
        {
            return actualExternalMapSearchParameters =>
                this.compareLogic.Compare(
                    expectedExternalMapSearchParameters,
                    actualExternalMapSearchParameters)
                        .AreEqual;
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();


        private static int GetRandomNumber(int min = 1, int max = 10) =>
            new IntRange(min, max + 1).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

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
