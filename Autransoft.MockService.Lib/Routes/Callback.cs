using System;
using System.Linq.Expressions;
using Autransoft.MockService.Lib.Entities;

namespace Autransoft.MockService.Lib.Routes
{
    ///<Summary>
    /// 
    ///</Summary>
    public class Callback
    {
        private Expression<Func<RequestEntity, ResponseEntity>> _callbackFunction;

        ///<Summary>
        /// 
        ///</Summary>
        public void WithFunction(Expression<Func<RequestEntity, ResponseEntity>> callbackFunction)
        {
            _callbackFunction = callbackFunction;
        }
    }
}