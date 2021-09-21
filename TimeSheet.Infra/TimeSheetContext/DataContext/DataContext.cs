using System;
using System.Data;
using System.Data.SqlClient;

namespace TimeSheet.Infra.TimeSheetContext.DataContext
{
    public class DataContext : IDisposable
    {
        public SqlConnection Conexao { get; set; }
        public DataContext()
        {
            Conexao = new SqlConnection("");
            Conexao.Open();
        }
        public void Dispose()
        {
            if (Conexao.State != ConnectionState.Closed)
                Conexao.Close();
        }
    }
}
