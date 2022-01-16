using Autransoft.MockService.Lib.Servers;

namespace Autransoft.MockService.Lib
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var api = new ApiServer();
            api.HttpClient.GetAsync("").Wait();
        }
    }
}
