

namespace PracticeExpression.Models
{
    //	Business rules are sbuject to change.

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsForSale { get; set; }
        public int InStock { get; set; }
        public bool IsAvailable => IsForSale && InStock > 0;

    }
}
