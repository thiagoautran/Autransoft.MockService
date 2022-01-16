using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Autransoft.Test.Lib.Controllers
{
    ///<Summary>
    /// 
    ///</Summary>
    [Produces("application/json")]
    [Route("autransoft/v1/mock/service")]
    public class AutransoftServerController : ControllerBase
    {
        ///<Summary>
        /// 
        ///</Summary>
        public AutransoftServerController()
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