// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Tests.Acceptance.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Tests.Acceptance.Models.Maps;
using Newtonsoft.Json;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace GottaGo.Core.Api.Tests.Acceptance.APIs.Maps
{
    public partial class MapApiTests
    {
        [Fact]
        public async Task ShouldSearchAddressAsync()
        {
            // given
            ExternalMapSearchResponse randomExternalMapSearchResponse = CreateRandomExternalMapSearchResponse();
            ExternalMapSearchResponse retrievedExternalMapSearchResponse = randomExternalMapSearchResponse;
            string retrievedExternalMapSearchResponseBody = JsonConvert.SerializeObject(retrievedExternalMapSearchResponse);

            List<Address> expectedRandomAddresses = randomExternalMapSearchResponse.Responses.Select(response =>
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

            this.wireMockServer
                .Given(Request.Create()
                    .WithPath("/search/address/json*")
                    .UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBody(retrievedExternalMapSearchResponseBody));

            // when
            List<Address> actualAddresses =
                await this.gottaGoCoreApiBroker.GetAddressesByQueryAsync(
                    randomAddressSearch.Query,
                    randomAddressSearch.CurrentLocation.Latitude,
                    randomAddressSearch.CurrentLocation.Longitude,
                    randomAddressSearch.Language,
                    String.Join(",", randomAddressSearch.Countries));

            // then
            actualAddresses.Should().BeEquivalentTo(expectedRandomAddresses);
        }
    }
}
