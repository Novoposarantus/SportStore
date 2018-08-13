using Domain.Entities;
using System.Linq;

namespace WebUI.Models {
    public class PurchaseListViewModel {
        public IQueryable<Purchases> Purchases { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}