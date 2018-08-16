using System;
using System.Collections.Generic;

namespace Domain.Entities {
    public class Purchase {
        public int Id { get; set; }
        public DateTime DateBuy { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartLine> Products { get; set; }

        public Purchase() 
        {
            this.Products = new List<CartLine>();
        }
    }
}
