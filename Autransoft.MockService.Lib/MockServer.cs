using Autransoft.MockService.Lib.Routes;
using Autransoft.MockService.Lib.Servers;
using Autransoft.MockService.Lib.Services;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;

namespace Autransoft.MockService.Lib
{
    ///<Summary>
    /// 
    ///</Summary>
    public class MockServer
    {
        private RouterService _routerService;
        private ApiServer _apiServer;

        ///<Summary>
        /// 
        ///</Summary>
        public HttpClient HttpClient { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public TestServer TestServer { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public MockServer()
        {
            _apiServer = new ApiServer();
            _apiServer.CreateHostBuilder();

            _routerService = new RouterService();
        }

        ///<Summary>
        /// 
        ///</Summary>
        public async Task StartAsync()
        {
            await _apiServer.StartAsync();
            HttpClient = _apiServer.HttpClient;
            TestServer = _apiServer.TestServer;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public void Clean() =>
            _routerService.Clean();

        ///<Summary>
        /// 
        ///</Summary>
        public async Task StopAsync()
        {
            _routerService.Clean();
            await _apiServer.StopAsync();
        }

        ///<Summary>
        /// 
        ///</Summary>
        public MockServer When(Request request, Response response)
        {
            _routerService.Add(request, response);
            return this;
        }
    }
}