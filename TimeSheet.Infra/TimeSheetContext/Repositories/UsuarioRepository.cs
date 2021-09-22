using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheet.Infra.TimeSheetContext.Repositories
{

    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Queries;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Infra.TimeSheetContext.DataContext;

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSession _session;

        public UsuarioRepository(DbSession _session)
        {
            this._session = _session ?? throw new ArgumentNullException(nameof(_session));
        }

        public async Task Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                string query = @"UPDATE Tb_Usuario SET Login = @Login, Senha = @Senha, DataAlteracao = @DataAlteracao,Ativo = @IsAtivo WHERE Id_Usuario=@Id";
                var antigo = Obter(id);

                if (antigo is not null)
                    await _session.Connection.ExecuteAsync(query, new { usuario.Login, usuario.Senha, usuario.DataAlteracao, usuario.IsAtivo, usuario.Id }, _session.Transaction);

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> ConsultarLoginExistente(string login)
        {
            try
            {
                var query = "SELECT Count(Id_Usuario) FROM Tb_Usuario WHERE  Login = @login AND Ativo=1";
                var result = await _session.Connection.QueryFirstOrDefaultAsync<int>(query, new { login }, _session.Transaction);
                _session.Dispose();
                return (result != 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Excluir(Guid id)
        {
            try
            {
                var usuario = await Obter(id);
                if (usuario is not null)
                {
                    usuario.IsAtivo = false;
                    await Atualizar(id, usuario);
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }

        public async Task<IEnumerable<ListarUsuarioQueryResult>> Listar()
        {
            try
            {
                var query = "SELECT Id_Usuario, Login, Senha FROM Tb_Usuario WHERE  Id_Usuario=@id AND Ativo=1";
                var result = await _session.Connection.QueryAsync<ListarUsuarioQueryResult>(query, _session.Transaction);
                _session.Dispose();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Novo(Usuario usuario)
        {
            try
            {
                string query = @"INSERT INTO Tb_Usuario (Id_Usuario, Login, Senha, DataCriacao, DataAlteracao, Ativo) 
                                 VALUES (@Id, @Login, @Senha, @DataCriacao, @DataAlteracao, @IsAtivo);";
                await _session.Connection.QuerySingleAsync(query, new { usuario.Id, usuario.Login, usuario.Senha, usuario.DataCriacao, usuario.DataAlteracao, usuario.IsAtivo }, _session.Transaction);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Usuario> Obter(Guid id)
        {
            try
            {
                var query = "SELECT * FROM Tb_Usuario WHERE  Id_Usuario=@id AND Ativo=1";
                var result = await _session.Connection.QueryFirstOrDefaultAsync<Usuario>(query, new { id }, _session.Transaction);
                _session.Dispose();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
