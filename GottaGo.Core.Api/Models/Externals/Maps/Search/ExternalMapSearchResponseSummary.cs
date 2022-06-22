// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

namespace GottaGo.Core.Api.Models.Externals.Maps.Search
{
    public class ExternalMapSearchResponseSummary
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        [JsonProperty("queryTime")]
        public int QueryTime { get; set; }

        [JsonProperty("numResults")]
        public int NumberOfResults { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("fuzzyLevel")]
        public int FuzzyLevel { get; set; }
    }
}