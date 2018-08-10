using Domain.Entities;
using System.Collections.Generic;

namespace WebUI.Models {
    public class PurchaseListViewModel {
        public IEnumerable<Purchases> Purchases { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}