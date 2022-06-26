// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

namespace GottaGo.Core.Api.Models.ExternalMaps.Search
{
    public class ExternalMapSearchResponse
    {
        [JsonProperty("summary")]
        public ExternalMapSearchResponseSummary Summary { get; set; }

        [JsonProperty("results")]
        public ExternalMapSearchResult[] Responses { get; set; }
    }
}