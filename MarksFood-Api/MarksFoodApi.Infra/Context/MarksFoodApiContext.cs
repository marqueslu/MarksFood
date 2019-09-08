using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Infra.Context
{
    public class MarksFoodApiContext : DbContext
    {
        public MarksFoodApiContext(DbContextOptions<MarksFoodApiContext> options) : base(options)
        {
        }

        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SnackMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
        }
    }
}
