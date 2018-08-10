using System;
using System.Collections.Generic;

namespace Domain.Entities {
    public class Purchases {
        public int Id { get; set; }
        public DateTime DateBuy { get; set; }
        public int UserId { get; set; }
        public ICollection<Product> Products { get; set; }
        public User User { get; set; }
        public Purchases() 
        {
            Products = new List<Product>();
        }
    }
}
