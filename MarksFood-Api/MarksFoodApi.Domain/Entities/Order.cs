using MarksFoodApi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarksFoodApi.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        public Order()
        {
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString();
        }

        public ICollection<OrderItem> Items => _items.ToArray();
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }

        public decimal Total() => Items.Sum(x => x.Total());

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
