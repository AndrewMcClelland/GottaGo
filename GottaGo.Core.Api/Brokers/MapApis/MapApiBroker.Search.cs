// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Threading.Tasks;
using GottaGo.Core.Api.Models.ExternalMaps.Search;

namespace GottaGo.Core.Api.Brokers.MapApis
{
    public partial class MapApiBroker : IMapApiBroker
    {
        private const string SearchRelativeUrl = "search/";
        private const string AddressRelativeUrl = "address/json?api-version=1.0";

        public async ValueTask<ExternalMapSearchResponse> GetSearchAddressAsync(
            ExternalMapSearchParameters externalMapSearchParameters)
        {
            string searchParameters = @$"&query={externalMapSearchParameters.Query}&
                                     typeahead={externalMapSearchParameters.TypeAhead}&
                                     limit={externalMapSearchParameters.ResponseLimit}&
                                     countrySet={externalMapSearchParameters.CountrySet}&
                                     lat={externalMapSearchParameters.Latitude}&
                                     lon={externalMapSearchParameters.Longitude}&
                                     radius={externalMapSearchParameters.ResultsRadiusMetres}&
                                     topLeft={externalMapSearchParameters.TopLeftBoundingBox}&
                                     btmRight={externalMapSearchParameters.BottomRightBoundingBox}&
                                     language={externalMapSearchParameters.Language}&
                                     extendedPostalCodesFor={externalMapSearchParameters.ExtendedPostalCodesFor}&
                                     entityType={externalMapSearchParameters.GeographicEntityType}";

            return await this.GetAsync<ExternalMapSearchResponse>(
                relativeUrl: @$"{SearchRelativeUrl}
                                {AddressRelativeUrl}
                                {searchParameters}");
        }
    }
}
