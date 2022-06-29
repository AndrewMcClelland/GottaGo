// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

namespace GottaGo.Core.Api.Tests.Acceptance.Models.ExternalMaps.Search
{
    public class ExternalMapSearchResponseAddress
    {
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("municipalitySubdivision")]
        public string MunicipalitySubdivision { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        [JsonProperty("countrySubdivisionName")]
        public string CountrySubdivisionName { get; set; }

        [JsonProperty("countrySubdivision")]
        public string CountrySubdivision { get; set; }

        [JsonProperty("countrySecondarySubdivision")]
        public string CountrySecondarySubdivision { get; set; }

        [JsonProperty("countryTertiarySubdivision")]
        public string CountryTertiarySubdivision { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("extendedPostalCode")]
        public string ExtendedPostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCodeISO3")]
        public string CountryCodeISO3 { get; set; }

        [JsonProperty("freeformAddress")]
        public string FreeformAddress { get; set; }
    }
}