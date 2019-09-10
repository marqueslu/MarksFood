using MarksFoodApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Dtos.Outputs
{
    public class DiscountOutput
    {
        public Guid IdIngredientAllowed { get; set; }
        public Guid? IdIngredientNotAllowed { get; set; }
        public EDiscountRule DiscountRule { get; set; }
        public bool Active { get; set; }
        public int? Quantity { get; set; }
        public float Percent { get; set; }
    }
}
