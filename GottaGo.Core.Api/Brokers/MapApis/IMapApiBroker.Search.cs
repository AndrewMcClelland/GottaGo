// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Threading.Tasks;
using GottaGo.Core.Api.Models.Externals.Maps.Search;

namespace GottaGo.Core.Api.Brokers.MapApis
{
    public partial interface IMapApiBroker
    {
        ValueTask<ExternalMapSearchResponse> GetSearchAddressAsync(
            ExternalMapSearchParameters externalMapSearchParameters);
    }
}
