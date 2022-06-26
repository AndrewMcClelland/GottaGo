// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
using GottaGo.Core.Api.Models.ExternalMaps.Search;
using GottaGo.Core.Api.Models.Maps;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public class MapService : IMapService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IMapApiBroker mapApiBroker;

        public MapService(ILoggingBroker loggingBroker, IMapApiBroker mapApiBroker)
        {
            this.loggingBroker = loggingBroker;
            this.mapApiBroker = mapApiBroker;
        }

        public async ValueTask<List<Address>> SearchAddress(AddressSearch addressSearch)
        {
            throw new NotImplementedException();
        }
    }
}
