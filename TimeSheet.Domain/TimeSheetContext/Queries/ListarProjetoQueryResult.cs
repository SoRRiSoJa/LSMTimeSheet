using System;
using System.Collections.Generic;
using TimeSheet.Domain.TimeSheetContext.Entities;

namespace TimeSheet.Domain.TimeSheetContext.Queries
{
    public class ListarProjetoQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Funcionario Responsavel { get; set; }
        public IEnumerable<Funcionario> Equipe { get; set; }
    }
}
