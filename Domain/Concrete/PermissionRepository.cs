using Domain.Entities;
using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Concrete
{
    public class PermissionRepository : IPermissionRepository
    {
        SportsStoreContext dbEntry = new SportsStoreContext();
        public IEnumerable<Permission> Permissions => dbEntry.Permissions;
        
    }
}
