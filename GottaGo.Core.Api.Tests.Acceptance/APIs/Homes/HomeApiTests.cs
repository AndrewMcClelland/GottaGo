// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using GottaGo.Core.Api.Tests.Acceptance.Brokers;
using Xunit;

namespace GottaGo.Core.Api.Tests.Acceptance.APIs.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly GottaGoCoreApiBroker gottaGoCoreApiBroker;

        public HomeApiTests(GottaGoCoreApiBroker gottaGoCoreApiBroker) =>
            this.gottaGoCoreApiBroker = gottaGoCoreApiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            // given
            string expectedMessage = "Hello from the other side!";

            // when
            string actualMessage = await this.gottaGoCoreApiBroker.GetHomeMessageAsync();

            // then
            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
