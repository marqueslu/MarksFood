using MarksFoodApi.Infra.DbSettings;
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

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
