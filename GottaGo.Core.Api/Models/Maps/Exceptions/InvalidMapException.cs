// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class InvalidMapException : Xeption
    {
        public InvalidMapException()
            : base(message: "Invalid map error occurred. Please fix the errors and try again.")
        { }
    }
}
