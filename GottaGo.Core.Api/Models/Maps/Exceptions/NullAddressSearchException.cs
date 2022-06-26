// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class NullAddressSearchException : Xeption
    {
        public NullAddressSearchException() :
            base(message: "AddressSearch is null.")
        { }
    }
}
