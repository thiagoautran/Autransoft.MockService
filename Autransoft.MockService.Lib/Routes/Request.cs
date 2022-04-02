using System.Collections.Generic;
using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Request
    {
        internal IDictionary<string, string> UpHeaders { get; private set; }
        internal IDictionary<string, string> Headers { get; private set; }
        internal IEnumerable<string> Query { get; private set; }
        internal string Path { get; private set; }
        internal string Body { get; private set; }
        internal Verbs Verb { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public Request()
        {
            UpHeaders = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
            Query = new List<string>();
            Body = string.Empty;
            Path = string.Empty;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithMethod(Verbs verb)
        {
            Verb = verb;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithPath(string path)
        {
            var index = path.IndexOf("?");
            if (index <= 0)
            {
                Path = path;
            }
            else
            {
                Path = path[..index];

                var list = new List<string>();
                var query = path[(index + 1)..];
                foreach (var item in query.Split("&"))
                {
                    if(!string.IsNullOrEmpty(item))
                        list.Add(item.Trim().ToUpper());
                }

                Query = list;
            }

            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithHeader(string name, string value)
        {
            UpHeaders.Add(name.Trim().ToUpper(), value.Trim().ToUpper());
            Headers.Add(name, value);
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Request WithBody(string json)
        {
            Body = json;
            return this;
        }
    }
}