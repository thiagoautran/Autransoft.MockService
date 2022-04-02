namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Route
    {
        internal Response Response { get; private set; }
        internal Callback Callback { get; private set; }
        internal Request Request { get; private set; }
        internal Forward Forward { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Response response)
        {
            Response = response;
            Request = request;

            Callback = null;
            Forward = null;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Forward forward)
        {
            Request = request;
            Forward = forward;

            Callback = null;
            Response = null;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Callback callback)
        {
            Callback = callback;
            Request = request;

            Response = null;
            Forward = null;
        }
    }
}