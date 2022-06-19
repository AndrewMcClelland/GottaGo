// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

// https://docs.microsoft.com/en-us/rest/api/maps/search/get-search-address#response

using Newtonsoft.Json;

public class ExternalMapSearchResponseViewport
{
    [JsonProperty("TopLeftPoint")]
    public ExternalMapSearchResponseLatitudeLongitude TopLeftPoint { get; set; }

    [JsonProperty("BtmRightPoint")]
    public ExternalMapSearchResponseLatitudeLongitude BottomRightPoint { get; set; }
}
