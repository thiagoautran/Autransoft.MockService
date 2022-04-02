using System.Collections.Generic;
using System.Linq;
using Autransoft.MockService.Lib.Extensions;
using Autransoft.MockService.Lib.Routes;
using Microsoft.AspNetCore.Http;

namespace Autransoft.MockService.Lib.Repositories
{
    ///<Summary>
    /// 
    ///</Summary>
    internal class RouterRepository
    {
        private static List<Route> _database;

        private static List<Route> Database
        {
            get
            {
                if(_database == null)
                    _database = new List<Route>();

                return _database;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="route"></param>
        public void Add(Route route)
        {
            if (route == null)
                return;

            Database.Add(route);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <param name="body"></param>
        /// <param name="query"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public Response Get(string method, string path, string body, IEnumerable<string> query, IHeaderDictionary header) =>
            Database.Where
            (
                route =>
                route.Request.Body.Trim().ToUpper() == body.Trim().ToUpper() &&
                route.Request.Verb.Method().Trim().ToUpper() == method.Trim().ToUpper() && 
                route.Request.Path.Trim().ToUpper().CutFirstCaracterWithSlash() == path.Trim().ToUpper().CutFirstCaracterWithSlash() &&
                route.Request.Query.ContainsAllComponents(query) &&
                route.Request.UpHeaders.ContainsAllComponents(header)
            ).Select(route => route.Response).FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        public void Clean() => _database = null;
    }
}