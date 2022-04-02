using Autransoft.MockService.Lib.Enums;
using Autransoft.MockService.Lib.Routes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class NotFound
    {
        [TestInitialize]
        public void TestInitialize() => TestConfiguration.MockServer.Clean();

        [TestMethod]
        public async Task ThereIsNoRoutes()
        {
            var response = await TestConfiguration.MockServer.HttpClient.GetAsync("api/v1/mockservice");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task RouteDoesNotExist()
        {
            TestConfiguration.MockServer
                .When
                (
                    new Request()
                        .WithMethod(Methods.Get)
                        .WithPath("api/v1/teste"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                );

            var response = await TestConfiguration.MockServer.HttpClient.GetAsync("api/v1/mockservice");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}