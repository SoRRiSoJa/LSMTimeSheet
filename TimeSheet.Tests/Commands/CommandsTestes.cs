using System;
using Xunit;

namespace TimeSheet.Tests.Commands
{
    using TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.FuncionarioCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.ProjetoCommands.Inputs;
    using TimeSheet.Domain.TimeSheetContext.Commands.UsuarioCommands.Inputs;

    public class CommandsTestes
    {

        public CommandsTestes()
        {

        }
        [Fact]
        public void DeveSerValidoComandoCriarUsuario()
        {
            var criarUsuarioCommand = new CriarUsuarioCommand
            {
                Login = "maria@hotmail.com",
                Senha = "2345678"
            };

            Assert.True(criarUsuarioCommand.Valid);
        }
        [Fact]
        public void DeveSerValidoComandoCriarFuncionario()
        {
            var criarFuncionarioCommand = new CriarFuncionarioCommand()
            {
                PrimeiroNome = "Joao Andre",
                Sobrenome = "Martins Dias e Silva",
                Cep = "19400-000",
                Logradouro = "Rua João Lopes de Oliveira",
                Complemento = "",
                Localidade = "Presidente Venceslau",
                Uf = "SP",
                Ibge = "",
                Gia = "",
                DDD = "18",
                Siafi = "",
                DDI = "55",
                Numero = "168",
                EmailURI = "jamdes@hotmail.com",
                NumeroDocumento = "218.551.898-44",
                Tipo = Domain.TimeSheetContext.Enums.ETipoDocumento.CPF,
                Usuario = Guid.NewGuid()
            };
            Assert.True(criarFuncionarioCommand.Valid);
        }
        [Fact]
        public void DeveSerValidoComandoCriarProjeto()
        {
            var criarProjetoCommand = new CriarProjetoCommand()
            {
                Nome = "LSM TimeShieet System v.1.0",
                Descricao = "Folha de ponto",
                Responsavel = Guid.NewGuid()
            };
            Assert.True(criarProjetoCommand.Valid);
        }
        [Fact]
        public void DeveSerValidoComandoCriarFolhaPonto()
        {
            var criarFolhaPontoCommand = new CriarFolhaPontoCommand()
            {
                Projeto = Guid.NewGuid(),
                Funcionario = Guid.NewGuid(),
                Data = DateTime.Now,
                HoraInicio = DateTime.Now,
                HoraFim = DateTime.Now.AddHours(1),
                Identificador = "2345678",
                Descricao = "Atividade teste"
            };
            Assert.True(criarFolhaPontoCommand.Valid);
        }

    }
}
