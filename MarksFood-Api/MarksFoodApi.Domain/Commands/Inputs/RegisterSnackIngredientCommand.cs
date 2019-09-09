using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class RegisterSnackIngredientCommand
    {
        public Guid IdIngredient { get; set; }
        public Guid IdSnack { get; set; }
        public int Quantity { get; set; }
    }
}
