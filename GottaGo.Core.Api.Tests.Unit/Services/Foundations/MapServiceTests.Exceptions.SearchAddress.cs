﻿// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.ExternalMaps.Search.Exceptions;
using GottaGo.Core.Api.Models.Maps;
using Moq;
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
                broker.GetSearchAddressAsync(It.IsAny<ExternalMapSearchParameters>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedMapDependencyException))),
                        Times.Once);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}