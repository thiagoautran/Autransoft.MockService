using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autransoft.MockService.Lib.Test
{
    [TestClass]
    public static class TestConfiguration
    {
        internal static MockServer MockServer;

        static TestConfiguration() => MockServer = new MockServer();

        [AssemblyInitialize]
        public static void ClassInitialize(TestContext context) => MockServer.StartAsync().Wait();

        [AssemblyCleanup]
        public static void ClassCleanup() => MockServer.StopAsync().Wait();
    }
}