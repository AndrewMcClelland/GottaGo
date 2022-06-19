// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#uri-parameters

namespace GottaGo.Core.Api.Models.Externals.Maps.Search
{
    public class ExternalMapSearchParameters
    {
        public string Query { get; set; }
        public int ResponseLimit { get; set; }
        public int ResultsRadiusMetres { get; set; }
        public bool TypeAhead { get; set; }
        public string TopLeftBoundingBox { get; set; }
        public string BottomRightBoundingBox { get; set; }
        public string CountrySet { get; set; }
        public string GeographicEntityType { get; set; }
        public string ExtendedPostalCodesFor { get; set; }
        public string Language { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
