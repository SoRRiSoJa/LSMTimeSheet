using System;

namespace TimeSheet.Domain.TimeSheetContext.Queries
{
    public class ListarUsuarioQueryResult
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
