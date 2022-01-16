using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autransoft.MockService.Lib.Servers;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public class SomeClassTests
    {
        [TestMethod]
        public async Task ShouldDoTest2()
        {
            var api = new ApiServer();
            var response = await api.HttpClient.GetAsync("api/v1/test");

            Assert.AreEqual(1, 1);
        }
    }
}
