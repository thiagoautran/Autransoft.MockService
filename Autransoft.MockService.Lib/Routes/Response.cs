using System;
using System.Collections.Generic;
using System.Net;

namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Response
    {
        private IDictionary<string, string> _headers;
        private HttpStatusCode _httpStatusCode;
        private TimeSpan _time;
        private string _json;

        ///<Summary>
        /// 
        ///</Summary>
        public Response()
        {
            _headers = new Dictionary<string, string>();
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithStatusCode(HttpStatusCode httpStatusCode)
        {
            _httpStatusCode = httpStatusCode;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithBody(string json)
        {
            _json = json;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithDelay(TimeSpan time)
        {
            _time = time;
            return this;
        }
    }
}