using FluentValidator;
using System.Threading.Tasks;
using System;
namespace TimeSheet.Domain.TimeSheetContext.Handlers
{

    using TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Outputs;
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    using TimeSheet.Shared.Commands;

    class FolhaPontoHandler : Notifiable, ICommandHandler<CriarFolhaPontoCommand>, ICommandHandler<AprovarFolhaPontoCommand>
    {
        private readonly IFolhaPontoRepository _repository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IProjetoRepository _projetoRepository;

        public FolhaPontoHandler(IFolhaPontoRepository _repository, IFuncionarioRepository _funcionarioRepository, IProjetoRepository _projetoRepository)
        {
            this._repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
            this._funcionarioRepository = _funcionarioRepository ?? throw new ArgumentNullException(nameof(_funcionarioRepository));
            this._projetoRepository = _projetoRepository ?? throw new ArgumentNullException(nameof(_projetoRepository));
        }

        #region CriarFolhaPontoHandler
        public async Task<ICommandResult> Handle(CriarFolhaPontoCommand command)
        {
            //TODO: Recuperar e validar funcionario
            //TODO:Recuperar e vlidar Projeto
            var funcionario = await _funcionarioRepository.Obter(command.Funcionario);
            if (funcionario is null)
                AddNotification("Funcionario", "Este funcionario não esta cadastrado.");

            var projeto = await _projetoRepository.Obter(command.Projeto);
            if (projeto is null)
                AddNotification("Projeto", "Este projeto não esta cadastrado.");

            // Criar os VOs
            var periodo = new Periodo(command.HoraInicio, command.HoraFim);


            // Criar a entidade
            var folhaPonto = new FolhaPonto(projeto, funcionario, command.Data, periodo, command.Identificador, command.Descricao);

            // Validar entidades e VOs
            AddNotifications(periodo.Notifications);
            AddNotifications(folhaPonto.Notifications);


            if (Invalid)
                return new CriarFolhaPontoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir a folha
            await _repository.Novo(folhaPonto);


            // Retornar o resultado para tela
            return new CriarFolhaPontoCommandResult(true, "atividade lançada com sucesso", new
            {
                folhaPonto.Id,
                projeto.Nome,
                funcionario.Nome.NomeCompleto,
            });
        }
        #endregion
        #region AprovarFolhaPontoHandler
        public async Task<ICommandResult> Handle(AprovarFolhaPontoCommand command)
        {

            var responsavel = await _funcionarioRepository.Obter(command.Responsavel);
            if (responsavel is null)
                AddNotification("responsavel", "Este funcionario não esta cadastrado.");

            var projeto = await _projetoRepository.Obter(command.Projeto);
            if (projeto is null)
                AddNotification("Projeto", "Este projeto não esta cadastrado.");
            if (await _projetoRepository.EResponsavelPeloProjeto(command.Projeto, command.Responsavel))
                AddNotification("Responsavel", "Você não é responsável pelo projeto, não pode reprovar..");

            var folhaPonto = await _repository.Obter(command.FolhaPonto);
            if (folhaPonto is null)
                AddNotification("FolhaPonto", "Você deve informar uma terfa a ser reprovada.");

            folhaPonto.AprovarTarefa();

            AddNotifications(folhaPonto.Notifications);


            if (Invalid)
                return new AprovarFolhaPontoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            await _repository.Alterar(command.FolhaPonto, folhaPonto);

            return new AprovarFolhaPontoCommandResult(true, "Atividade reprovada pelo responsável com sucesso", new
            {
                IdTarefa = folhaPonto.Id,
                NomeResponsavel = folhaPonto.Projeto.Responsavel.Nome.NomeCompleto,
                NomeFuncionario = folhaPonto.Funcionario.Nome.NomeCompleto,
            });
        }
        #endregion
        #region ReprovarFolhaPontoHandler
        public async Task<ICommandResult> Handle(ReprovarFolhaPontoCommand command)
        {

            var responsavel = await _funcionarioRepository.Obter(command.Responsavel);
            if (responsavel is null)
                AddNotification("responsavel", "Este funcionario não esta cadastrado.");

            var projeto = await _projetoRepository.Obter(command.Projeto);
            if (projeto is null)
                AddNotification("Projeto", "Este projeto não esta cadastrado.");
            if (await _projetoRepository.EResponsavelPeloProjeto(command.Projeto, command.Responsavel))
                AddNotification("Responsavel", "Você não é responsável pelo projeto, não pode reprovar..");

            var folhaPonto = await _repository.Obter(command.FolhaPonto);
            if (folhaPonto is null)
                AddNotification("FolhaPonto", "Você deve informar uma terfa a ser reprovada.");

            folhaPonto.ReprovarTarefa();

            AddNotifications(folhaPonto.Notifications);


            if (Invalid)
                return new ReprovarFolhaPontoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            await _repository.Alterar(command.FolhaPonto, folhaPonto);

            return new ReprovarFolhaPontoCommandResult(true, "Atividade reprovada pelo responsável com sucesso", new
            {
                IdTarefa=folhaPonto.Id,
                NomeResponsavel=folhaPonto.Projeto.Responsavel.Nome.NomeCompleto,
                NomeFuncionario=folhaPonto.Funcionario.Nome.NomeCompleto,
            });
        }
        #endregion
    }
}
