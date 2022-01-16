using Autransoft.MockService.Lib.Servers;

namespace Autransoft.MockService.Lib
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Program
    {
        ///<Summary>
        /// 
        ///</Summary>
        public static void Main(string[] args)
        {
            var api = new ApiServer();
            api.HttpClient.GetAsync("").Wait();
        }
    }
}
