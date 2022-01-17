using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Autransoft.MockService.Lib.Routes;
using Autransoft.MockService.Lib.Servers;
using Microsoft.AspNetCore.TestHost;

namespace Autransoft.MockService.Lib
{
    ///<Summary>
    /// 
    ///</Summary>
    public class MockServer
    {
        private ApiServer _apiServer;
        private List<Route> _route;

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
            _apiServer.CreateHost(host, port);

            _route = new List<Route>();
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
        }

        ///<Summary>
        /// 
        ///</Summary>
        public MockServer When(Request request, Response response)
        {
            _route.Add(new Route(request, response));
            return this;
        }
    }
}