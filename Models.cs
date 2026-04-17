using System;

namespace AccountingSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}