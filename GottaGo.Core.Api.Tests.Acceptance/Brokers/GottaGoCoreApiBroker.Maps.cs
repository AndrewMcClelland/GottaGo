// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using GottaGo.Core.Api.Tests.Acceptance.Models.Maps;

namespace GottaGo.Core.Api.Tests.Acceptance.Brokers
{
    public partial class GottaGoCoreApiBroker
    {
        private const string MapsRelativeUrl = "api/maps";

        public async ValueTask<List<Address>> GetAddressesByQueryAsync(string query,
                                                                       double? latitude,
                                                                       double? longitude,
                                                                       string language,
                                                                       string countries)
        {
            string urlParameters = $"?query={query}&" +
                                   $"latitude={latitude}&" +
                                   $"longitude={longitude}&" +
                                   $"language={language}&" +
                                   $"countries={countries}";

            return await this.apiFactoryClient.GetContentAsync<List<Address>>(
                relativeUrl: $"{MapsRelativeUrl}{urlParameters}");
        }
    }
}
