using Domain.Entities;
using System.Collections.Generic;

namespace WebUI.Models {
    public class PurchaseListViewModel {
        public IEnumerable<Purchase> Purchases { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}