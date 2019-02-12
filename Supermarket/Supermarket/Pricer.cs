using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class Pricer
    {
        internal IEnumerable<decimal> GetPrices(IEnumerable<Item> items, IEnumerable<ItemPrice> priceList)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (priceList == null)
                throw new ArgumentNullException(nameof(priceList));

            var missingNames = items.Where(i => string.IsNullOrWhiteSpace(i.Name));
            if (missingNames.Any())
            {
                throw new ArgumentException($"{nameof(Item)}.{nameof(Item.Name)} cannot be null or whitespace.");
            }

            return ApplyPricing(items, priceList);
        }

        private IEnumerable<decimal> ApplyPricing(IEnumerable<Item> items, IEnumerable<ItemPrice> priceList)
        {
            var prices = from item in items
                          join pl in priceList on item.Name equals pl.Name
                          select new
                          {
                              item.Name,
                              Price = pl.Number > 0 ?
                                       pl.DiscountPrice * Math.Floor(Convert.ToDecimal(item.Number / pl.Number)) + pl.Price * (item.Number % pl.Number) :
                                       item.Number * pl.Price
                          };

            return prices.Select(s => s.Price);
        }
    }
}
