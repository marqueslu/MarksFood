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
        public EDiscountRule discountRule { get; set; }
        public bool active { get; set; }
        public int? quantity { get; set; }
        public decimal discountPercent { get; set; }
    }
}
