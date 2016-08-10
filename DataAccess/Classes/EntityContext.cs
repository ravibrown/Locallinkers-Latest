using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EntityContext
    {
        public LocalLinkersEntities _db;
        public EntityContext()
        {
            _db = new LocalLinkersEntities();
        }
    }
}
