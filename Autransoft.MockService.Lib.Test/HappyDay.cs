using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autransoft.MockService.Lib.Routes;
using Autransoft.MockService.Lib.Enums;
using FluentAssertions;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class HappyDay
    {
        internal static MockServer MockServer;

        public HappyDay() => MockServer = new MockServer("192.168.0.1", 1080);

        [TestInitialize]
        public async Task ClassInitialize() => await MockServer.StartAsync();

        [TestCleanup]
        public async Task ClassCleanup() => await MockServer.StopAsync();

        [TestMethod]
        public async Task Get()
        {
            MockServer
                .When
                (
                    new Request()
                        .WithMethod(Verbs.Get)
                        .WithPath("api/v1/mockservice"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                );

            var response = await MockServer.HttpClient.GetAsync("api/v1/mockservice");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("{ message: 'incorrect username and password combination'}");

            Assert.IsTrue(response.Headers.TryGetValues("Content-Type", out IEnumerable<string> values1) || response.Content.Headers.TryGetValues("Content-Type", out IEnumerable<string> values2));
            Assert.IsTrue(response.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values3) || response.Content.Headers.TryGetValues("Cache-Control", out IEnumerable<string> values4));
        }

        [TestMethod]
        public async Task Delay()
        {
            MockServer
                .When
                (
                    new Request()
                        .WithMethod(Verbs.Get)
                        .WithPath("api/v1/mockservice"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.GatewayTimeout)
                        .WithDelay(new TimeSpan(0, 0, 20))
                );

            var start = DateTime.Now;
            var response = await MockServer.HttpClient.GetAsync("api/v1/mockservice");
            var timeSpan = DateTime.Now - start;

            timeSpan.Seconds.Should().Be(20);
            response.StatusCode.Should().Be(HttpStatusCode.GatewayTimeout);
        }

        [TestMethod]
        public async Task Post()
        {
            var obj = new { UserName = "foo", Password = "bar" };
            var json = JsonSerializer.Serialize(obj);

            MockServer
                .When
                (
                    new Request()
                        .WithMethod(Verbs.Post)
                        .WithPath("api/v1/mockservice")
                        .WithBody(json),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                );

            var response = await MockServer.HttpClient.PostAsync
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
    }
}