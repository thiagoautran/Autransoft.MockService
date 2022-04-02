using Autransoft.MockService.Lib.Extensions;
using Autransoft.MockService.Lib.Repositories;
using Autransoft.MockService.Lib.Routes;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Autransoft.MockService.Lib.Services
{
    internal class RouterService
    {
        private readonly RouterRepository _repository;

        public RouterService() => _repository = new RouterRepository();

        ///<Summary>
        /// 
        ///</Summary>
        public void Clean() => _repository.Clean();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void Add(Request request, Response response)
        {
            if (request == null || response == null)
                return;

            _repository.Add(new Route(request, response));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        /// <returns>httpResponse</returns>
        public async Task<HttpResponse> GetResponse(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            var header = httpRequest.Headers;
            var method = httpRequest.Method;
            var query = httpRequest.QueryAsList();
            var body = httpRequest.BodyAsString();
            var path = httpRequest.Path.Value;

            var response = _repository.Get(method, path, body, query, header);

            if (response == null)
            {
                httpResponse.StatusCode = (int)HttpStatusCode.NotFound;
                return httpResponse;
            }

            httpResponse.Headers.Clear();
            foreach (var key in response.Headers.Keys)
                httpResponse.Headers.Append(key, response.Headers[key]);

            httpResponse.StatusCode = (int)response.HttpStatusCode;

            await httpResponse.WriteAsync(response.Body, System.Text.Encoding.UTF8);

            if(response.Delay != null)
                await Task.Delay(response.Delay.Value);

            return httpResponse;
        }
    }
}