using System.IO;
using System.Threading.Tasks;
using Autransoft.MockService.Lib.Services;
using Microsoft.AspNetCore.Http;

namespace Autransoft.MockService.Lib.Middlewares
{
    internal class RequestMiddleware
    {
        private RequestDelegate _next;
        private readonly RouterService _routerService;

        public RequestMiddleware(RequestDelegate next)
        {
            _routerService = new RouterService();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            using (var ms = new MemoryStream())
            {
                await httpContext.Request.Body.CopyToAsync(ms);
                httpContext.Request.ContentLength = ms.Length;
            }
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            await _routerService.GetResponse(httpContext.Request, httpContext.Response);
        }
    }
}