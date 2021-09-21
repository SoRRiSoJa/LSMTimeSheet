using FluentValidator;
using System;
using System.Threading.Tasks;

namespace TimeSheet.Domain.TimeSheetContext.Handlers
{
    using TimeSheet.Domain.TimeSheetContext.Commands.UsuarioCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.UsuarioCommands.Outputs;
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Shared.Commands;

    public class UsuarioHandler : Notifiable, ICommandHandler<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioHandler(IUsuarioRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
        }
        public async Task<ICommandResult> Handle(CriarUsuarioCommand command)
        {
            // Verificar se o login já existe na base
            if (await _repository.ConsultarLoginExistente(command.Login))
                AddNotification("Login", "Este login já está em uso");


            // Criar os VOs

            // Criar a entidade
            var usuario = new Usuario(command.Login, command.Senha);

            // Validar entidades e VOs
            AddNotifications(usuario.Notifications);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir o cliente
            await _repository.Novo(usuario);


            // Retornar o resultado para tela
            return new CriarUsuarioCommandResult(true, "Bem vindo ao balta Store", new
            {
                usuario.Id,
                usuario.Login,
            });
        }
    }
}
