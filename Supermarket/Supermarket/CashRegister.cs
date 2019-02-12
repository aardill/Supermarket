using Supermarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class CashRegister : ICashRegister
    {
        private Pricer pricer;

        public CashRegister()
        {
            pricer = new Pricer(); //would normally do this with dependency injection
        }

        public decimal Total(IEnumerable<Item> items, IEnumerable<ItemPrice> itemPrices)
        {
            var totals = pricer.GetPrices(items, itemPrices);
            return totals.Sum(s => s);
        }
    }
}
