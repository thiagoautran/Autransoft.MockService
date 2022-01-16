using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Autransoft.MockService.Lib.Servers
{
    ///<Summary>
    /// 
    ///</Summary>
    public class ApiServer : IDisposable
    {
        ///<Summary>
        /// 
        ///</Summary>
        public IHost Host { get; private set; }

        private HttpClient _httpClient;

        ///<Summary>
        /// 
        ///</Summary>
        public HttpClient HttpClient 
        { 
            get
            {
                if (Host == null)
                    Host = CreateHost();

                if (_httpClient == null)
                    _httpClient = Host.GetTestClient();

                return _httpClient;
            }
        }

        private IHost CreateHost()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "IntegrationTest");
                    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "IntegrationTest");
                    webHostBuilder.UseEnvironment("IntegrationTest");

                    webHostBuilder.UseTestServer();
                    webHostBuilder.UseStartup<Startup>();
                });

            var task = hostBuilder.StartAsync();
            task.Wait();

            return task.Result;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public void Dispose()
        {
            HttpClientDispose();

            HostDispose();
        }

        private void HttpClientDispose()
        {
            if(_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }
        }

        private void HostDispose()
        {
            if(Host != null)
            {
                var task = Host.StopAsync();
                task.Wait();

                Host.Dispose();
            }
        }
    }
}