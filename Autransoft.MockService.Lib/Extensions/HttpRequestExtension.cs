using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autransoft.MockService.Lib.Extensions
{
    internal static class HttpRequestExtension
    {
        internal static string BodyAsString(this HttpRequest httpRequest)
        {
            if (httpRequest.ContentLength == null || httpRequest.ContentLength == 0)
                return string.Empty;

            var buffer = new byte[Convert.ToInt32(httpRequest.ContentLength)];
            httpRequest.Body.ReadAsync(buffer, 0, buffer.Length).Wait();

            return Encoding.UTF8.GetString(buffer);
        }

        internal static IEnumerable<string> QueryAsList(this HttpRequest request)
        {
            var queries = new List<string>();

            if (request == null || request.Query == null || request.Query.Keys == null)
                return queries;

            foreach (var key in request.Query.Keys)
            {
                if (request.Query.TryGetValue(key, out StringValues value))
                {
                    queries.Add($"{key.Trim().ToUpper()}={value.ToString().Trim().ToUpper()}");
                }
            }

            return queries;
        }
    }
}