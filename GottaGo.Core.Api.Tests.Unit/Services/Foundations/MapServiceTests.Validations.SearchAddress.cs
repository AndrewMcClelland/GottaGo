// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Models.Maps.Exceptions;
using Moq;
using Xunit;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        [Fact]
        public async void ShouldThrowValidationExceptionOnSearchIfNullAndLogItAsync()
        {
            // given
            AddressSearch nullAddressSearch = null;
            var nullAddressSearchException = new NullAddressSearchException();
            var expectedMapValidationException = new MapValidationException(nullAddressSearchException);

            // when
            ValueTask<List<Address>> searchAddressTask = this.mapService.SearchAddress(nullAddressSearch);

            MapValidationException actualMapValidationException =
                await Assert.ThrowsAsync<MapValidationException>(
                    searchAddressTask.AsTask);

            // then
            actualMapValidationException.Should().BeEquivalentTo(expectedMapValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMapValidationException))),
                        Times.Once);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(
                    It.IsAny<ExternalMapSearchParameters>()),
                        Times.Never);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void ShouldThrowValidationExceptionOnSearchIfAddressIsInvalidAndLogItAsync(
            string invalidString)
        {
            // given
            var invalidAddressSearch = new AddressSearch
            {
                Query = invalidString
            };

            var invalidMapException = new InvalidMapException();

            invalidMapException.AddData(
                key: nameof(AddressSearch.Query),
                values: "Query is required");

            var expectedMapValidationException = new MapValidationException(invalidMapException);

            // when
            ValueTask<List<Address>> searchAddressTask = this.mapService.SearchAddress(invalidAddressSearch);

            MapValidationException actualMapValidationException =
                await Assert.ThrowsAsync<MapValidationException>(
                    searchAddressTask.AsTask);

            // then
            actualMapValidationException.Should().BeEquivalentTo(expectedMapValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMapValidationException))),
                        Times.Once);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(
                    It.IsAny<ExternalMapSearchParameters>()),
                        Times.Never);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
