// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
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

        public ValueTask<List<Address>> SearchAddress()
        {
            throw new System.NotImplementedException();
        }
    }
}
