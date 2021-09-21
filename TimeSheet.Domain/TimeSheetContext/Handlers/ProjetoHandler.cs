using FluentValidator;
using System;
using System.Threading.Tasks;

namespace TimeSheet.Domain.TimeSheetContext.Handlers
{
    using TimeSheet.Domain.TimeSheetContext.Commands.ProjetoCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.ProjetoCommands.Outputs;
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Shared.Commands;
    public class ProjetoHandler : Notifiable, ICommandHandler<CriarProjetoCommand>
    {

        private readonly IProjetoRepository _repository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        public ProjetoHandler(IProjetoRepository _repository, IFuncionarioRepository _funcionarioRepository)
        {
            this._repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
            this._funcionarioRepository = _funcionarioRepository ?? throw new ArgumentNullException(nameof(_funcionarioRepository));
        }
        public async Task<ICommandResult> Handle(CriarProjetoCommand command)
        {
            // Verificar se o responável existe
            var responsavel = await _funcionarioRepository.Obter(command.Responsavel);
            if (responsavel is null)
                AddNotification("ProjetoHandler", "Estefuncionario não existe");



            // Criar a entidade
            var projeto = new Projeto(command.Nome, command.Descricao, responsavel);


            //// Validar entidades e VOs
            AddNotifications(responsavel.Notifications);
            AddNotifications(projeto.Notifications);

            if (Invalid)
                return new CriarProjetoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir o projeto
            await _repository.Novo(projeto);


            // Retornar o resultado para tela
            return new CriarProjetoCommandResult(true, "Projeto criado com sucesso", new
            {
                projeto.Id,
                projeto.Nome,
                projeto.Descricao
            });
        }
    }
}
