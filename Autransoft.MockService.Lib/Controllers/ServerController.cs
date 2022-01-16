using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Autransoft.Test.Lib.Controllers
{
    public class ServerController : ControllerBase
    {
        public ServerController()
        {
        }

        [HttpGet]
        public async Task<ContentResult> GetAsync()
        {
            try
            {
                return new ContentResult 
                {
                    ContentType = "text/html",
                    Content = "test"
                };
            }
            catch (Exception ex)
            {
                return new ContentResult 
                {
                    ContentType = "text/html",
                    Content = ex.Message
                };
            }
        }
    }
}