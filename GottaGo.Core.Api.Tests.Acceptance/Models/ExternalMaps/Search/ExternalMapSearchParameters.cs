// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#uri-parameters

namespace GottaGo.Core.Api.Tests.Acceptance.Models.ExternalMaps.Search
{
    public class ExternalMapSearchParameters
    {
        public string Query { get; set; }
        public string ResponseLimit { get; set; }
        public string ResultsRadiusMetres { get; set; }
        public string TypeAhead { get; set; }
        public string TopLeftBoundingBox { get; set; }
        public string BottomRightBoundingBox { get; set; }
        public string CountrySet { get; set; }
        public string GeographicEntityType { get; set; }
        public string ExtendedPostalCodesFor { get; set; }
        public string Language { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
