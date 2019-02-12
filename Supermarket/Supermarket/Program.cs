using Supermarket.Models;
using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 0m;

            //I will just hard code the data to be passed in as we don't have an actual scanner. 
            //The calling code would obviously create this
            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 2 },
                new Item { Name = "Banana", Number = 3 },
                new Item { Name = "Peach", Number = 1 }
           };

            //because discounts are variable, we'll treat the price list separately from the item list
            var priceList = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
                new ItemPrice { Name = "Banana", Price = 50, Number = 3, DiscountPrice = 130 },
                new ItemPrice { Name = "Peach", Price = 60 },
            };

            var cashRegister = new CashRegister(); //would normally inject a ICashRegister via dependency injection or use a factory, but for the sake of speed I'll skip that. 
            total = cashRegister.Total(items, priceList);

            Console.Write(total);
        }
    }
}
