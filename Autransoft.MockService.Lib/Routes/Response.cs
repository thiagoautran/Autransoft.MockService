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
        internal IDictionary<string, string> Headers { get; private set; }
        internal HttpStatusCode HttpStatusCode { get; private set; }
        internal TimeSpan? Delay { get; private set; }
        internal string Body { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public Response()
        {
            Headers = new Dictionary<string, string>();
            Body = string.Empty;
            Delay = null;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithStatusCode(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithHeader(string name, string value)
        {
            Headers.Add(name, value);
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithBody(string json)
        {
            Body = json;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Response WithDelay(TimeSpan time)
        {
            Delay = time;
            return this;
        }
    }
}