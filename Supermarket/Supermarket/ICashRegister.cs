using Supermarket.Models;
using System.Collections.Generic;

namespace Supermarket
{
    interface ICashRegister
    {
        decimal Total(IEnumerable<Item> items, IEnumerable<ItemPrice> priceList);
    }
}
