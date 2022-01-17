using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Forward
    {
        private string _host;
        private string _port;
        private Scheme _scheme;

        ///<Summary>
        /// 
        ///</Summary>
        public Forward WithHost(string host)
        {
            _host = host;
            return this;
        }
        
        ///<Summary>
        /// 
        ///</Summary>
        public Forward WithPort(string port)
        {
            _port = port;
            return this;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Forward WithScheme(Scheme scheme)
        {
            _scheme = scheme;
            return this;
        }
    }
}