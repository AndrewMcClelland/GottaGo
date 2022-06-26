// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;
using Moq;
using Xunit;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        [Fact]
        public async Task ShouldSearchAddressAsync()
        {
            // given
            ExternalMapSearchResponse randomExternalMapSearchResponse = CreateRandomExternalMapSearchResponse();
            ExternalMapSearchResponse retrievedExternalMapSearchResponse = randomExternalMapSearchResponse;

            List<Address> expectedAddresses = randomExternalMapSearchResponse.Responses.Select(response =>
                new Address
                {
                    Type = response.Type,
                    StreetNumber = response.Address.StreetNumber,
                    StreetName = response.Address.StreetName,
                    MunicipalitySubdivision = response.Address.MunicipalitySubdivision,
                    Municipality = response.Address.Municipality,
                    CountrySubdivisionName = response.Address.CountrySubdivisionName,
                    CountrySubdivision = response.Address.CountrySubdivision,
                    CountrySecondarySubdivision = response.Address.CountrySecondarySubdivision,
                    CountryTertiarySubdivision = response.Address.CountryTertiarySubdivision,
                    PostalCode = response.Address.PostalCode,
                    ExtendedPostalCode = response.Address.ExtendedPostalCode,
                    Country = response.Address.Country,
                    CountryCode = response.Address.CountryCode,
                    CountryCodeISO3 = response.Address.CountryCodeISO3,
                    FreeformAddress = response.Address.FreeformAddress,
                    Coordinates = new Coordinates
                    {
                        Latitude = response.Position.Latitude,
                        Longitude = response.Position.Longitude
                    },
                    BoundingBox = new BoundingBox
                    {
                        TopLeftPoint = new Coordinates
                        {
                            Latitude = response.Viewport.TopLeftPoint.Latitude,
                            Longitude = response.Viewport.TopLeftPoint.Longitude,
                        },
                        BottomRightPoint = new Coordinates
                        {
                            Latitude = response.Viewport.BottomRightPoint.Latitude,
                            Longitude = response.Viewport.BottomRightPoint.Longitude,
                        },
                    }
                }).ToList();

            AddressSearch randomAddressSearch = CreateRandomAddressSearch();
            AddressSearch inputAddressSearch = randomAddressSearch;
            var expectedExternalMapSearchParameters = new ExternalMapSearchParameters
            {
                Query = inputAddressSearch.Query,
                Language = inputAddressSearch.Language,
                CountrySet = String.Join(",", inputAddressSearch.Countries),
                Latitude = inputAddressSearch.CurrentLocation.Latitude,
                Longitude = inputAddressSearch.CurrentLocation.Longitude,

            };

            this.mapApiBrokerMock.Setup(broker =>
                broker.GetSearchAddressAsync(It.Is(
                    SameInformationAs(expectedExternalMapSearchParameters))))
                        .ReturnsAsync(retrievedExternalMapSearchResponse);

            // when
            List<Address> actualAddresses = await this.mapService.SearchAddress(inputAddressSearch);

            // then
            actualAddresses.Should().BeEquivalentTo(expectedAddresses);

            this.mapApiBrokerMock.Verify(broker =>
                broker.GetSearchAddressAsync(It.Is(
                    SameInformationAs(expectedExternalMapSearchParameters))),
                        Times.Once);

            this.mapApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
