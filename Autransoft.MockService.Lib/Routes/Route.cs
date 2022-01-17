namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Route
    {
        private Response _response;
        private Callback _callback;
        private Request _request;
        private Forward _forward;

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Response response)
        {
            _response = response;
            _request = request;
            
            _callback = null;
            _forward = null;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Forward forward)
        {
            _request = request;
            _forward = forward;

            _callback = null;
            _response = null;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Callback callback)
        {
            _callback = callback;
            _request = request;
            
            _response = null;
            _forward = null;
        }
    }
}