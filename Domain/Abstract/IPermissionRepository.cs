using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IPermissionRepository
    {
        IEnumerable<Permission> Permissions { get; }
    }
}
