// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;
using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class FailedMapDependencyException : Xeption
    {
        public FailedMapDependencyException(Exception innerException)
            : base(message: "Failed map dependency error occurred, please contact support.",
                  innerException)
        { }
    }
}
