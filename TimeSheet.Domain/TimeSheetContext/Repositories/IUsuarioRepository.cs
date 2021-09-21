using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheet.Domain.TimeSheetContext.Repositories
{
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Queries;

    public interface IUsuarioRepository
    {
        Task Novo(Usuario usuario);
        Task Atualizar(Guid id, Usuario usuario);
        Task Excluir(Guid id);
        Task<Usuario> Obter(Guid id);
        Task<bool> ConsultarLoginExistente(string login);
        Task<IEnumerable<ListarUsuarioQueryResult>> Listar();
    }
}
