using System.Collections.Generic;
using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Request
    {
        private IDictionary<string, string> _headers;
        private string _path;
        private string _json;
        private Verbs _verb;

        ///<Summary>
        /// 
        ///</Summary>
        public Request()
        {
            _headers = new Dictionary<string, string>();
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithMethod(Verbs verb)
        {
            _verb = verb;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithPath(string path)
        {
            _path = path;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithBody(string json)
        {
            _json = json;
            return this;
        }
    }
}