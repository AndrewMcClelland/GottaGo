﻿// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xunit;

namespace GottaGo.Core.Api.Tests.Acceptance.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<GottaGoCoreApiBroker>
    { }
}
