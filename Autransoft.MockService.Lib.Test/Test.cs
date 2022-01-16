using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autransoft.MockService.Lib;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class SomeClassTests
    {
        [TestMethod]
        public async Task ShouldDoTest2()
        {
            var mockService = new MockService("192.168.0.1", 1080);
            await mockService.StartAsync();

            var response = await mockService.HttpClient.GetAsync("autransoft/v1/mock/service");

            await mockService.StopAsync();

            Assert.AreEqual(1, 1);
        }
    }
}
