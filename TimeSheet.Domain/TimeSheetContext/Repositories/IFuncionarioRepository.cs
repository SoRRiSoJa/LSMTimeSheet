using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheet.Domain.TimeSheetContext.Repositories
{
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Queries;

    public interface IFuncionarioRepository
    {
        Task Novo(Funcionario funcionario);
        Task Atualizar(Guid id, Funcionario funcionario);
        Task Excluir(Guid id);
        Task<Funcionario> Obter(Guid id);
        Task<bool> ConsultarFuncionarioExistente(string numeroDocumento);
        Task<bool> ConsultarFuncionarioExistente(Guid idFuncionario);
        Task<IEnumerable<ListarFuncionarioQueryResult>> Listar();
        Task<IEnumerable<ListarProjetoQueryResult>> ListarProjetos();
        void ListarFolhaPonto();
        void ListarFolhaPorProjeto(Guid idProjeto);
        void ListarFolhaPorDataLanamento(DateTime dataLancamento);
        void ListarFolhaPorDataLanamentoEProjeto(DateTime dataLancamento, Guid idProjeto);

    }
}
