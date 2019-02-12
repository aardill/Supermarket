using Supermarket;
using Supermarket.Models;
using System.Collections.Generic;
using Xunit;

namespace SupermarketTests
{
    public class SupermarketTests
    {
        [Fact]
        static void MultipleItemsTest()
        {
            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 2 },
                new Item { Name = "Banana", Number = 3 },
                new Item { Name = "Peach", Number = 1 }
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
                new ItemPrice { Name = "Banana", Price = 50, Number = 3, DiscountPrice = 130 },
                new ItemPrice { Name = "Peach", Price = 60 },
            };

            Assert.Equal(235, sut.Total(items, itemPrices));
        }

        [Fact]
        static void MultipleDiscountMultipleItemsTest()
        {
            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 2 },
                new Item { Name = "Banana", Number = 5 },
                new Item { Name = "Peach", Number = 1 },
                new Item { Name = "Apple", Number = 1 },
                new Item { Name = "Banana", Number = 3 }
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
                new ItemPrice { Name = "Banana", Price = 50, Number = 3, DiscountPrice = 130 },
                new ItemPrice { Name = "Peach", Price = 60 },
            };

            Assert.Equal(495, sut.Total(items, itemPrices));
        }
    }
}
