using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Autransoft.MockService.Lib.Routes;
using Autransoft.MockService.Lib.Servers;
using Autransoft.MockService.Lib.Services;
using Microsoft.AspNetCore.TestHost;

namespace Autransoft.MockService.Lib
{
    ///<Summary>
    /// 
    ///</Summary>
    public class MockServer
    {
        private ApiServer _apiServer;
        private RouterService _routerService;

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
        public MockServer(string host, uint port)
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
        public async Task StopAsync()
        {
            await _apiServer.StopAsync();
            _routerService.Clean();
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