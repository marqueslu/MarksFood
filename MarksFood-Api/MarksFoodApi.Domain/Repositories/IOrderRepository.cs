using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
