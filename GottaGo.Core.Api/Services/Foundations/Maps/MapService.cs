// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public partial class MapService : IMapService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IMapApiBroker mapApiBroker;

        public MapService(ILoggingBroker loggingBroker, IMapApiBroker mapApiBroker)
        {
            this.loggingBroker = loggingBroker;
            this.mapApiBroker = mapApiBroker;
        }

        public ValueTask<List<Address>> SearchAddress(AddressSearch addressSearch) =>
        TryCatch(async () =>
        {
            ValidateAddressSearchOnSearch(addressSearch);

            var externalMapSearchParameters = new ExternalMapSearchParameters
            {
                Query = addressSearch.Query,
                Language = addressSearch.Language,
                CountrySet = String.Join(",", addressSearch.Countries),
                Latitude = addressSearch.CurrentLocation.Latitude?.ToString(),
                Longitude = addressSearch.CurrentLocation.Longitude?.ToString()
            };

            ExternalMapSearchResponse externalMapSearchResponse =
                await this.mapApiBroker.GetSearchAddressAsync(externalMapSearchParameters);

            List<Address> addresses = externalMapSearchResponse.Responses.Select(response =>
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

            return addresses;
        });
    }
}
