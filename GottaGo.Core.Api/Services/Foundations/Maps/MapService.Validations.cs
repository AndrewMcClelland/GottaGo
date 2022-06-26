// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using GottaGo.Core.Api.Models.Maps;
using GottaGo.Core.Api.Models.Maps.Exceptions;

namespace GottaGo.Core.Api.Services.Foundations.Maps
{
    public partial class MapService
    {
        private void ValidateAddressSearchOnSearch(AddressSearch addressSearch)
        {
            ValidateAddressSearchIsNotNull(addressSearch);
        }

        private void ValidateAddressSearchIsNotNull(AddressSearch addressSearch)
        {
            if(addressSearch is null)
            {
                throw new NullAddressSearchException();
            }
        }
    }
}
