using MarksFoodApi.Shared.Entities;

namespace MarksFoodApi.Domain.Entities
{
    public class Ingredient : Entity
    {
        protected Ingredient()
        {

        }

        public Ingredient(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public void AddQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
