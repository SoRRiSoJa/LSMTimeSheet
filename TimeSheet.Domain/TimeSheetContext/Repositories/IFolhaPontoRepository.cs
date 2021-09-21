using System;
using System.Threading.Tasks;
namespace TimeSheet.Domain.TimeSheetContext.Repositories
{
    using TimeSheet.Domain.TimeSheetContext.Entities;
    public interface IFolhaPontoRepository
    {
        Task Novo(FolhaPonto folhaPOnto);
        Task<FolhaPonto> Obter(Guid idFolhaPonto);
        Task Excluir(Guid idFolhaPonto);
        void ListarPorFuncionario(Guid idFuncionario);
        void ListarPorProjeto(Guid idProjeto);
        void ListarPorProjetoEFuncionario(Guid idProjeto, Guid idFuncionario);
        Task AprovarAtividade(Guid idFolhaPonto);
        Task ReprovarAtividade(Guid idFolhaPonto);
    }
}
