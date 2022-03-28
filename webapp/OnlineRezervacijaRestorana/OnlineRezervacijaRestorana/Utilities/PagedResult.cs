using System;
using System.Collections.Generic;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Utilities
{
    public class PagedResult<TEntity> : PagedResultBase where TEntity : class, IEntity
    {
        public IList<TEntity> Results { get; set; }

        public PagedResult()
        {
            Results = new List<TEntity>();
        }
    }
}
