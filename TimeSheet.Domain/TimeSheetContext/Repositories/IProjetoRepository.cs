using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace TimeSheet.Domain.TimeSheetContext.Repositories
{
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Queries;

    public interface IProjetoRepository
    {
        Task Novo(Projeto projeto);
        Task Atualizar(Guid id, Projeto projeto);
        Task<Projeto> Obter(Guid id);
        Task<IEnumerable<ListarFuncionarioQueryResult>> ListarEquipeDoProjeto();
        Task<bool> EResponsavelPeloProjeto(Guid idProjeto, Guid idFuncionario);
        Task<bool> PertenceAEquipeProjeto(Guid idProjeto, Guid idFuncionario);
        Task<bool> AdiconarFuncionarioAEquipe(Guid idFuncionario);
        Task ExcluirFuncionarioDaEquipe(Guid idFuncionario);
    }
}
