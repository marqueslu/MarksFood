using MarksFoodApi.Shared.DbSettings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MarksFoodApi.Infra.Context
{
    public class MarksFoodApiDbContext : IDisposable
    {

        public SqlConnection Connection { get; set; }

        public MarksFoodApiDbContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
        }
        //public MarksFoodApiDbContext(DbContextOptions<MarksFoodApiContext> options) : base(options)
        //{
        //}

        //public DbSet<Snack> Snacks { get; set; }
        //public DbSet<Ingredient> Ingredients { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new SnackMap());
        //    modelBuilder.ApplyConfiguration(new IngredientMap());
        //}
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
