using MarksFoodApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Infra.Mappings
{
    public class SnackMap : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.ToTable("Snack");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.HasMany(x => x.Ingredients);
        }
    }
}
