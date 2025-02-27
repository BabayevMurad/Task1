﻿namespace HomeWork.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }

        public string ImagePath { get; set; } = "sa";
    }
}
