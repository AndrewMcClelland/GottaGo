// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

namespace GottaGo.Core.Api.Models.Externals.Maps.Search
{
    public class ExternalMapSearchResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("address")]
        public ExternalMapSearchResponseAddress Address { get; set; }

        [JsonProperty("position")]
        public ExternalMapSearchResponseLatitudeLongitude Position { get; set; }

        [JsonProperty("viewport")]
        public ExternalMapSearchResponseViewport Viewport { get; set; }

        [JsonProperty("entryPoints")]
        public ExternalMapSearchResponseEntrypoint[] EntryPoints { get; set; }
    }
}