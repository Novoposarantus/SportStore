using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Purchase> PurchaseHistory { get; set; }
    }
}
