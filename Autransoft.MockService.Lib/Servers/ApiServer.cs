using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Autransoft.MockService.Lib.Configurations;
using Autransoft.MockService.Lib.Routes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Autransoft.MockService.Lib.Servers
{
    ///<Summary>
    /// 
    ///</Summary>
    internal class ApiServer
    {
        private IHostBuilder _hostBuilder;
        private HttpClient _httpClient;
        private TestServer _testServer;
        private IHost _host;

        ///<Summary>
        /// 
        ///</Summary>
        public HttpClient HttpClient { get { return _httpClient; }}

        ///<Summary>
        /// 
        ///</Summary>
        public TestServer TestServer { get { return _testServer; }}

        ///<Summary>
        /// 
        ///</Summary>
        public void CreateHostBuilder() =>
            _hostBuilder = CreateHostBuilder(new string[0]);

        private IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                });

        ///<Summary>
        /// 
        ///</Summary>
        public async Task StartAsync()
        {
            _host = await _hostBuilder.StartAsync();
            _httpClient = _host.GetTestClient();
            _testServer = _host.GetTestServer();
        }

        ///<Summary>
        /// 
        ///</Summary>
        public async Task StopAsync()
        {
            HttpClientDispose();
            TestServerDispose();

            await HostDispose();
        }

        private void HttpClientDispose()
        {
            if(_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }
        }

        private void TestServerDispose()
        {
            if(_testServer != null)
            {
                _testServer.Dispose();
                _testServer = null;
            }
        }

        private async Task HostDispose()
        {
            if(_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
        }
    }
}