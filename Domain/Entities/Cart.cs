﻿using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Cart
    {
        List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(l => l.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Product.Price * l.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
