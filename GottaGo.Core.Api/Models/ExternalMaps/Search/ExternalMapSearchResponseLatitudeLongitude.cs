// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

namespace GottaGo.Core.Api.Models.ExternalMaps.Search
{
    public class ExternalMapSearchResponseLatitudeLongitude
    {
        [JsonProperty("Lat")]
        public float Latitude { get; set; }

        [JsonProperty("Lon")]
        public float Longitude { get; set; }
    }
}