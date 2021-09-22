using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TimeSheet.Infra.TimeSheetContext.DataContext
{
    public sealed class DbSession : IDisposable
    {
        private readonly IConfiguration _configuration;
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public DbSession(IConfiguration _configuration)
        {
            this._configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
            try
            {
                Connection = new SqlConnection(_configuration.GetConnectionString("TimeSheet"));
                Connection.Open();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
        public void Dispose() => Connection?.Dispose();

    }
}
