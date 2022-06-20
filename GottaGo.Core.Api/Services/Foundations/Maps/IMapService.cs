// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public interface IMapService
    {
        ValueTask<List<>> SearchAddress();
    }
}
