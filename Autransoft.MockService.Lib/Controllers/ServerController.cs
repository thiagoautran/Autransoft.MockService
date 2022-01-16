using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Autransoft.Test.Lib.Controllers
{
    ///<Summary>
    /// 
    ///</Summary>
    [Produces("application/json")]
    [Route("api/v1/test")]
    public class ServerController : ControllerBase
    {
        ///<Summary>
        /// 
        ///</Summary>
        public ServerController()
        {
        }

        ///<Summary>
        /// 
        ///</Summary>
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