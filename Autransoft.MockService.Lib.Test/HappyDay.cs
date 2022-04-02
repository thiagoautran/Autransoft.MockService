using Autransoft.MockService.Lib.Enums;
using Autransoft.MockService.Lib.Routes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class HappyDay
    {
        [TestInitialize]
        public void TestInitialize() => TestConfiguration.MockServer.Clean();

        [TestMethod]
        public async Task Get()
        {
            TestConfiguration.MockServer
                .When
                (
                    new Request()
                        .WithMethod(Methods.Get)
                        .WithPath("api/v1/mockservice"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                );

            var response = await TestConfiguration.MockServer.HttpClient.GetAsync("api/v1/mockservice");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("{ message: 'incorrect username and password combination'}");

            Assert.IsTrue(response.Headers.TryGetValues("Content-Type", out IEnumerable<string> values1) || response.Content.Headers.TryGetValues("Content-Type", out IEnumerable<string> values2));
            Assert.IsTrue(response.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values3) || response.Content.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values4));
        }

        [TestMethod]
        public async Task Delay()
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

        [TestMethod]
        public async Task Post()
        {
            var obj = new { UserName = "foo", Password = "bar" };
            var json = JsonSerializer.Serialize(obj);

            TestConfiguration.MockServer
                .When
                (
                    new Request()
                        .WithMethod(Methods.Post)
                        .WithPath("api/v1/mockservice")
                        .WithBody(json),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                );

            var response = await TestConfiguration.MockServer.HttpClient.PostAsync
            (
                "api/v1/mockservice", 
                new StringContent
                (
                    json, 
                    System.Text.Encoding.UTF8,
                    "application/json"
                )
            );

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("{ message: 'incorrect username and password combination'}");

            Assert.IsTrue(response.Headers.TryGetValues("Content-Type", out IEnumerable<string> values1) || response.Content.Headers.TryGetValues("Content-Type", out IEnumerable<string> values2));
            Assert.IsTrue(response.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values3) || response.Content.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values4));
        }

        [TestMethod]
        public async Task NotFound()
        {
            var response = await TestConfiguration.MockServer.HttpClient.GetAsync("api/v1/mockservice");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}