// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.Configurations;
using Microsoft.Extensions.Configuration;
using RESTFulSense.Clients;

namespace GottaGo.Core.Api.Brokers.MapApis
{
    public partial class MapApiBroker : IMapApiBroker
    {
        private const string ApiName = "AzureMaps";
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;
        private readonly string clientId;
        private readonly string apiKey;

        public MapApiBroker(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.clientId = GetApiClientId(configuration);
            this.apiKey = GetApiKey(configuration);
            this.apiClient = GetApiClient(configuration);
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.apiClient.GetContentAsync<T>(relativeUrl);

        private static string GetApiClientId(IConfiguration configuration)
        {
            LocalConfigurations localConfigurations = configuration.Get<LocalConfigurations>();

            return localConfigurations.ApiConfigurations[ApiName].ClientId;
        }

        private static string GetApiKey(IConfiguration configuration)
        {
            LocalConfigurations localConfigurations = configuration.Get<LocalConfigurations>();

            return localConfigurations.ApiConfigurations[ApiName].ApiKey;
        }

        private IRESTFulApiFactoryClient GetApiClient(IConfiguration configuration)
        {
            LocalConfigurations localConfigurations = configuration.Get<LocalConfigurations>();
            string apiBaseUrl = localConfigurations.ApiConfigurations[ApiName].Url;
            this.httpClient.BaseAddress = new Uri(apiBaseUrl);
            this.httpClient.DefaultRequestHeaders.Add(name: "x-ms-client-id",
                                                      value: this.clientId);

            return new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}
