// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Models.Maps.Exceptions;
using Moq;
using RESTFulSense.Exceptions;
using Xeptions;
using Xunit;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        [Theory]
        [MemberData(nameof(CriticalDependencyException))]
        public async Task ShouldThrowCriticalDependencyExceptionOnRetrieveIfCriticalErrorOccursAndLogItAsync(
            Xeption criticalDependencyException)
        {
            // given
            var failedMapDependencyException = new FailedMapDependencyException(criticalDependencyException);
            var expectedMapDependencyException = new MapDependencyException(failedMapDependencyException);

            AddressSearch inputAddressSearch = CreateRandomAddressSearch();

            mapApiBrokerMock.Setup(broker =>
                broker.GetSearchAddressAsync(
                        It.IsAny<ExternalMapSearchParameters>()))
                            .ThrowsAsync(criticalDependencyException);

            // when
            ValueTask<List<Address>> searchAddressTask = this.mapService.SearchAddress(inputAddressSearch);

            MapDependencyException actualMapDependencyException =
                await Assert.ThrowsAsync<MapDependencyException>(
                    searchAddressTask.AsTask);

            // then
            actualMapDependencyException.Should().BeEquivalentTo(actualMapDependencyException);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(
                    It.IsAny<ExternalMapSearchParameters>()),
                        Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedMapDependencyException))),
                        Times.Once);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfErrorOccursAndLogItAsync()
        {
            // given
            var someResponseMessage = new HttpResponseMessage();
            var someMessage = GetRandomString();
            var httpResponseException = new HttpResponseException(someResponseMessage, someMessage);
            var failedMapDependencyException = new FailedMapDependencyException(httpResponseException);
            var expectedMapDependencyException = new MapDependencyException(failedMapDependencyException);

            AddressSearch inputAddressSearch = CreateRandomAddressSearch();

            mapApiBrokerMock.Setup(broker =>
                broker.GetSearchAddressAsync(
                        It.IsAny<ExternalMapSearchParameters>()))
                            .ThrowsAsync(httpResponseException);

            // when
            ValueTask<List<Address>> searchAddressTask = this.mapService.SearchAddress(inputAddressSearch);

            MapDependencyException actualMapDependencyException =
                await Assert.ThrowsAsync<MapDependencyException>(
                    searchAddressTask.AsTask);

            // then
            actualMapDependencyException.Should().BeEquivalentTo(actualMapDependencyException);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(
                    It.IsAny<ExternalMapSearchParameters>()),
                        Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMapDependencyException))),
                        Times.Once);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfErrorOccursAndLogItAsync()
        {
            // given
            var exception = new Exception();
            var failedMapServiceException = new FailedMapServiceException(exception);
            var expectedMapServiceException = new MapServiceException(failedMapServiceException);

            AddressSearch inputAddressSearch = CreateRandomAddressSearch();

            mapApiBrokerMock.Setup(broker =>
                broker.GetSearchAddressAsync(
                        It.IsAny<ExternalMapSearchParameters>()))
                            .ThrowsAsync(exception);

            // when
            ValueTask<List<Address>> searchAddressTask = this.mapService.SearchAddress(inputAddressSearch);

            MapServiceException actualMapServiceException =
                await Assert.ThrowsAsync<MapServiceException>(
                    searchAddressTask.AsTask);

            // then
            actualMapServiceException.Should().BeEquivalentTo(expectedMapServiceException);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(
                    It.IsAny<ExternalMapSearchParameters>()),
                        Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMapServiceException))),
                        Times.Once);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
