﻿namespace Challenge.Domain
{
    public class Order
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }

        public void Validate()
        {
            if (Product == null)
            {
                throw new Exception("Products are required");
            }

            if (Quantity <= 0)
            {
                throw new Exception("Quantity is required");
            }
        }
    }
}
