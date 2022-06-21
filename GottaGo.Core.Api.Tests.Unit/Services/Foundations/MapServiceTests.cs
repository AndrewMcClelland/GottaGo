// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using GottaGo.Core.Api.Brokers.Loggings;
using GottaGo.Core.Api.Brokers.MapApis;
using Moq;

namespace GottaGo.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class MapServiceTests
    {
        private readonly Mock<IMapApiBroker> mapApiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
    }
}
