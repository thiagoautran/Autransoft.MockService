namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Route
    {
        internal Response Response { get; private set; }
        internal Request Request { get; private set; }

        ///<Summary>
        /// 
        ///</Summary>
        public Route(Request request, Response response)
        {
            Response = response;
            Request = request;
        }
    }
}