﻿namespace Domain.Entities {
    public class Purchases {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
