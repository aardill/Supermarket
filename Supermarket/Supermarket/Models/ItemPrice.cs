namespace Supermarket.Models
{
    public class ItemPrice : Item
    {
        public decimal Price { get; set; } //usually use decimals for money calculations
        public decimal DiscountPrice { get; set; }
    }
}
