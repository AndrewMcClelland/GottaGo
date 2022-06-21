// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using GottaGo.Core.Api.Models.Maps;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public interface IMapService
    {
        ValueTask<List<Address>> SearchAddress();
    }
}
