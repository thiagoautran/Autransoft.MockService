using Autransoft.MockService.Lib.Enums;
using Autransoft.MockService.Lib.Routes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class Delay
    {
        [TestInitialize]
        public void TestInitialize() => TestConfiguration.MockServer.Clean();

        [TestMethod]
        public async Task Wait20Seconds()
        {
            TestConfiguration.MockServer
                .When
                (
                    new Request()
                        .WithMethod(Methods.Get)
                        .WithPath("api/v1/mockservice"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.GatewayTimeout)
                        .WithDelay(new TimeSpan(0, 0, 20))
                );

            var start = DateTime.Now;
            var response = await TestConfiguration.MockServer.HttpClient.GetAsync("api/v1/mockservice");
            var timeSpan = DateTime.Now - start;

            timeSpan.Seconds.Should().Be(20);
            response.StatusCode.Should().Be(HttpStatusCode.GatewayTimeout);
        }
    }
}