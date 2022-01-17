using System.Collections.Generic;
using Autransoft.MockService.Lib.Entities;

namespace Autransoft.MockService.Lib.Repositories
{
    ///<Summary>
    /// 
    ///</Summary>
    public class RouterRepository
    {
        private Dictionary<RequestEntity, BaseEntity> _database;

        private Dictionary<RequestEntity, BaseEntity> Database
        {
            get
            {
                if(_database == null)
                    _database = new Dictionary<RequestEntity, BaseEntity>();

                return _database;
            }
        }

        ///<Summary>
        /// 
        ///</Summary>
        public void Add(RequestEntity request, BaseEntity response)
        {
            if(request == null || response == null)
                return;

            _database.Add(request, response);
        }
    }
}