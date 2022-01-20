using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autransoft.MockService.Lib;
using Autransoft.MockService.Lib.Routes;
using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class SomeClassTests
    {
        [TestMethod]
        public async Task ShouldDoTest2()
        {
            var mockService = new MockServer("192.168.0.1", 1080);
            await mockService.StartAsync();

            mockService
                .When
                (
                    new Request()
                        .WithMethod(Verbs.Post)
                        .WithPath("validate1")
                        .WithHeader("Content-type", "application/json")
                        .WithBody("{username: 'foo', password: 'bar'}"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                        .WithDelay(new TimeSpan(0, 0, 1))
                )
                .When
                (
                    new Request()
                        .WithMethod(Verbs.Post)
                        .WithPath("validate2")
                        .WithHeader("Content-type", "application/json")
                        .WithBody("{username: 'foo', password: 'bar'}"),
                    new Response()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithHeader("Cache-Control", "public, max-age=86400")
                        .WithBody("{ message: 'incorrect username and password combination'}")
                        .WithDelay(new TimeSpan(0, 0, 1))
                );

            var response = await mockService.HttpClient.GetAsync("autransoft/v1/mock/service");

            await mockService.StopAsync();

            Assert.AreEqual(1, 1);
        }
    }
}
