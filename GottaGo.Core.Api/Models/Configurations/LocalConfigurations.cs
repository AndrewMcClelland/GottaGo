// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;

namespace GottaGo.Core.Api.Models.Configurations
{
    public class LocalConfigurations
    {
        public IDictionary<string, ApiConfigurations> ApiConfigurations { get; set; }
    }
}
