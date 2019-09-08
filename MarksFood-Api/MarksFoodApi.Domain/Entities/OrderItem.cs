using System.Linq;

namespace MarksFoodApi.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(Snack snack, decimal discount)
        {
            Snack = snack;
            Discount = discount;
        }

        public Snack Snack { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Snack.Ingredients.Sum(x => x.Price * x.Quantity);
        public decimal Total() => SubTotal() - Discount;
    }
}
