using System.Net.Http;
using System.Threading.Tasks;
using Autransoft.MockService.Lib.Servers;
using Microsoft.AspNetCore.TestHost;

namespace Autransoft.MockService.Lib
{
    ///<Summary>
    /// 
    ///</Summary>
    public class MockService
    {
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
        public MockService(string host, uint port)
        {
            _apiServer = new ApiServer();
            _apiServer.CreateHost(host, port);
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
    }
}