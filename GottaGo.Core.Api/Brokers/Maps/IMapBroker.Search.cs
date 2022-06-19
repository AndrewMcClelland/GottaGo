// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Threading.Tasks;
using GottaGo.Core.Api.Models.Externals.Maps.Search;

namespace GottaGo.Core.Api.Brokers.Maps
{
    public partial interface IMapBroker
    {
        ValueTask<ExternalMapSearchResponse> GetSearchAddressAsync(
            ExternalMapSearchParameters externalMapSearchParameters);
    }
}
