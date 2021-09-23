using FluentValidator;
using System;
using System.Threading.Tasks;

namespace TimeSheet.Domain.TimeSheetContext.Handlers
{
    using TimeSheet.Domain.TimeSheetContext.Commands.FuncionarioCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.FuncionarioCommands.Outputs;
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Domain.TimeSheetContext.Services;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    using TimeSheet.Shared.Commands;

    public class FuncionarioHandler : Notifiable, ICommandHandler<CriarFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICEPService _cepService;
        public FuncionarioHandler(IFuncionarioRepository _repository, IUsuarioRepository _usuarioRepository, ICEPService _cepService)
        {
            this._repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
            this._usuarioRepository = _usuarioRepository ?? throw new ArgumentNullException(nameof(_usuarioRepository));
            this._cepService = _cepService ?? throw new ArgumentNullException(nameof(_cepService));
        }

        public async Task<ICommandResult> Handle(CriarFuncionarioCommand command)
        {
            // Verificar se o CPF já existe na base
            if (await _repository.ConsultarFuncionarioExistente(command.NumeroDocumento))
                AddNotification("Document", "Este documento já está cadastrado");

            // Criar os VOs
            var nome = new Nome(command.PrimeiroNome, command.Sobrenome);
            var documento = new Documento(command.NumeroDocumento, command.Tipo);
            var telefone = new Telefone(command.DDI, command.DDD, command.Numero);

            var endereco = await _cepService.Obter(command.Cep);

            var email = new Email(command.EmailURI);

            // Criar a entidade
            var usuario = await _usuarioRepository.Obter(command.Usuario);
            var funcionario = new Funcionario(nome, endereco, telefone, email, documento, usuario, command.CategoriaFuncionario);

            // Validar entidades e VOs
            AddNotifications(nome.Notifications);
            AddNotifications(documento.Notifications);
            AddNotifications(telefone.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(endereco.Notifications);
            AddNotifications(usuario.Notifications);
            AddNotifications(funcionario.Notifications);

            if (Invalid)
                return new CriarFuncionarioCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir o cliente
            await _repository.Novo(funcionario);


            // Retornar o resultado para tela
            return new CriarFuncionarioCommandResult(true, "Funcionário criado com sucesso", new
            {
                funcionario.Id,
                funcionario.Nome.NomeCompleto,
                email.EmailURI
            });
        }
    }
}
