// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.ExternalMaps.Search;

namespace GottaGo.Core.Api.Brokers.MapApis
{
    public partial class MapApiBroker : IMapApiBroker
    {
        private const string RelativeUrl = "search/address";

        public async ValueTask<ExternalMapSearchResponse> GetSearchAddressAsync(
            ExternalMapSearchParameters externalMapSearchParameters)
        {
            string searchParameters = "json?" +
                                     UrlParameterCheck("query", externalMapSearchParameters.Query) +
                                     UrlParameterCheck("typeahead", externalMapSearchParameters.TypeAhead) +
                                     UrlParameterCheck("limit", externalMapSearchParameters.ResponseLimit) +
                                     UrlParameterCheck("countrySet", externalMapSearchParameters.CountrySet) +
                                     UrlParameterCheck("lat", externalMapSearchParameters.Latitude) +
                                     UrlParameterCheck("lon", externalMapSearchParameters.Longitude) +
                                     UrlParameterCheck("radius", externalMapSearchParameters.ResultsRadiusMetres) +
                                     UrlParameterCheck("topLeft", externalMapSearchParameters.TopLeftBoundingBox) +
                                     UrlParameterCheck("btmRight", externalMapSearchParameters.BottomRightBoundingBox) +
                                     UrlParameterCheck("language", externalMapSearchParameters.Language) +
                                     UrlParameterCheck("extendedPostalCodesFor", externalMapSearchParameters.ExtendedPostalCodesFor) +
                                     UrlParameterCheck("entityType", externalMapSearchParameters.GeographicEntityType) +
                                     $"subscription-key={this.apiKey}&" +
                                     $"api-version=1.0";

            return await this.GetAsync<ExternalMapSearchResponse>(
                relativeUrl: $"{RelativeUrl}" +
                             $"{searchParameters}");
        }

        private static string UrlParameterCheck(string name, string value) =>
            String.IsNullOrWhiteSpace(value) ? "" : $"{name}={value}&";

        private static string UrlParameterCheck(string name, int? value) =>
            value is null ? "" : $"{name}={value}&";

        private static string UrlParameterCheck(string name, double? value) =>
            value is null ? "" : $"{name}={value}&";

        private static string UrlParameterCheck(string name, bool? value) =>
            value is null ? "" : $"{name}={value}&";
    }
}
