﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class IngredientOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? Quantity { get; set; }
    }
}
