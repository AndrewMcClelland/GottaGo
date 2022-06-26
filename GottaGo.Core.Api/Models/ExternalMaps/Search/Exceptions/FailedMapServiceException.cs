// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using Xeptions;

namespace GottaGo.Core.Api.Models.ExternalMaps.Search.Exceptions
{
    public class FailedMapServiceException : Xeption
    {
        public FailedMapServiceException(Exception innerException)
            : base(message: "Failed map service error occurred, please contact support.",
                  innerException)
        { }
    }
}
