// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Threading.Tasks;
using GottaGo.Core.Api.Models.ExternalMaps.Search;

namespace GottaGo.Core.Api.Brokers.MapApis
{
    public partial class MapApiBroker : IMapApiBroker
    {
        private const string RelativeUrl = "search/address/";

        public async ValueTask<ExternalMapSearchResponse> GetSearchAddressAsync(
            ExternalMapSearchParameters externalMapSearchParameters)
        {
            string searchParameters = "json?" +
                                     $"query={externalMapSearchParameters.Query}&" +
                                     $"typeahead={externalMapSearchParameters.TypeAhead}&" +
                                     $"limit={externalMapSearchParameters.ResponseLimit}&" +
                                     $"countrySet={externalMapSearchParameters.CountrySet}&" +
                                     $"lat={externalMapSearchParameters.Latitude}&" +
                                     $"lon={externalMapSearchParameters.Longitude}&" +
                                     $"radius={externalMapSearchParameters.ResultsRadiusMetres}&" +
                                     $"topLeft={externalMapSearchParameters.TopLeftBoundingBox}&" +
                                     $"btmRight={externalMapSearchParameters.BottomRightBoundingBox}&" +
                                     $"language={externalMapSearchParameters.Language}&" +
                                     $"extendedPostalCodesFor={externalMapSearchParameters.ExtendedPostalCodesFor}&" +
                                     $"entityType={externalMapSearchParameters.GeographicEntityType}&" +
                                     $"subscription-key={this.apiKey}&" +
                                     $"api-version=1.0";

            return await this.GetAsync<ExternalMapSearchResponse>(
                relativeUrl: $"{RelativeUrl}" +
                             $"{searchParameters}");
        }
    }
}
