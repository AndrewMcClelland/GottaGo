﻿// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

public class ExternalMapSearchResponseEntrypoint
{
    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Position")]
    public ExternalMapSearchResponseLatitudeLongitude Position { get; set; }
}
