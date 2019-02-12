using Supermarket;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SupermarketTests
{
    public class SupermarketTests
    {
        [Fact]
        static void PassingNullValuesThrowsException()
        {
            //arrange
            //would normally just mock these values with moq or autofixture or you could roll your own, but for the sake of speed I'll skip that. 
            var sut = new CashRegister();
            IEnumerable<Item> items = null;
            IEnumerable<ItemPrice> itemPrices = null;

            //act
            Action act = () => sut.Total(items, itemPrices);
            //assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        static void PassingEmptyItemNamesThrowsException()
        {
            //arrange
            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "", Number = 1 },
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
            };

            //act
            Action act = () => sut.Total(items, itemPrices);
            //assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        static void ZeroItemsReturnsZeroTest()
        {
            var sut = new CashRegister();

            var items = new List<Item>
            {
            };
            var itemPrices = new List<ItemPrice>
            {
            };

            Assert.Equal(0, sut.Total(items, itemPrices));
        }

        [Fact]
        static void SingleItemTest()
        {
            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 1 },
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
            };

            Assert.Equal(30, sut.Total(items, itemPrices));
        }

        [Fact]
        static void OneOfEachItemTest()
        {

            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 1 },
                new Item { Name = "Banana", Number = 1 },
                new Item { Name = "Peach", Number = 1 }
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
                new ItemPrice { Name = "Banana", Price = 50, Number = 3, DiscountPrice = 130 },
                new ItemPrice { Name = "Peach", Price = 60 },
            };

            Assert.Equal(140, sut.Total(items, itemPrices));
        }

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
        static void SingleDiscountSingleItemTest()
        {
            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 2 }, //single discount will be applied
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
            };

            Assert.Equal(45, sut.Total(items, itemPrices));
        }

        [Fact]
        static void MultipleDiscountSingleItemTest()
        {

            var sut = new CashRegister();

            var items = new List<Item>
            {
                new Item { Name = "Apple", Number = 5 }, //discount needs to be applied twice
            };
            var itemPrices = new List<ItemPrice>
            {
                new ItemPrice { Name = "Apple", Price = 30, Number = 2, DiscountPrice = 45 },
            };

            Assert.Equal(120, sut.Total(items, itemPrices));
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
                new Item { Name = "Banana", Number = 3 } //banana and apple entered twice => multiple discount variable order
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
