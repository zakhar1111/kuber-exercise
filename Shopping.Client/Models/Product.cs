﻿namespace Shopping.Client.Models
{
    public class Product
    {
        public string Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageFile { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}