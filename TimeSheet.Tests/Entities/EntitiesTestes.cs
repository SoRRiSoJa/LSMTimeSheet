using System;
using TimeSheet.Domain.TimeSheetContext.Entities;
using TimeSheet.Domain.TimeSheetContext.Enums;
using TimeSheet.Domain.TimeSheetContext.ValueObjects;
using Xunit;

namespace TimeSheet.Tests.Entities
{
    public class EntitiesTestes
    {
        private readonly Nome _nomeVo;
        private readonly Telefone _telefoneVo;
        private readonly Email _emailVo;
        private readonly Documento _documentoCPFVo;
        private readonly Endereco _enderecoVo;
        private readonly Usuario _usuario;
        private readonly Funcionario _funcionarioGerente;
        private readonly Funcionario _funcionarioDesenvolvedor;
        private readonly Projeto _projeto;
        private readonly FolhaPonto _folhaDePonto;
        private readonly Periodo _periodoVo;

        public EntitiesTestes()
        {
            _nomeVo = new Nome("João André", "Martins Dias e Silva");
            _telefoneVo = new Telefone("55", "18", "981225687");
            _emailVo = new Email("jamdes@hotmail.com");
            _documentoCPFVo = new Documento("218.551.898-44", ETipoDocumento.CPF);
            _enderecoVo = new Endereco("19000-000", "Joao Lopes de Oliveira 168", "", "Centro", "Presidente Venceslau", "SP", "", "", "18", "");

            _usuario = new Usuario("jamdes@hotmail.com", "198119");
            _funcionarioGerente = new Funcionario(_nomeVo, _enderecoVo, _telefoneVo, _emailVo, _documentoCPFVo, _usuario, ECategoriaFuncionario.GERENTE);
            _funcionarioDesenvolvedor = new Funcionario(_nomeVo, _enderecoVo, _telefoneVo, _emailVo, _documentoCPFVo, _usuario, ECategoriaFuncionario.DESENVOLVEDOR);
            _projeto = new Projeto("LSM TimeSheet v1.0", "Large shit Maker TimeSheet System", _funcionarioGerente);
            _periodoVo = new Periodo(DateTime.Now, DateTime.Now.AddMinutes(30));
            _folhaDePonto = new FolhaPonto(_projeto, _funcionarioDesenvolvedor, DateTime.Now, _periodoVo, "2345678", "Nova atividade de teste");
        }
        [Fact]
        public void DadoUmNovoUsuarioValidoDevoTerUmaAvaliacaoPositiva()
        {
            Assert.False(_usuario.Invalid);
        }
        [Fact]
        public void DadoUmNovoFuncionarioValidoDevoTerUmaAvaliacaoPositiva()
        {
            Assert.False(_funcionarioDesenvolvedor.Invalid);
        }
        [Fact]
        public void DadoUmNovoProjetoValidoDevoTerUmaAvaliacaoPositiva()
        {
            Assert.False(_projeto.Invalid);
        }
        [Fact]
        public void DevoTerPeloMenosUmMenbroNaequipeaposDicionarUmFuncionario()
        {
            _projeto.AdicionarFuncionario(_funcionarioDesenvolvedor);

            Assert.Single(_projeto.Equipe);
        }
        [Fact]
        public void DadoUmaNovaFolhaDePontoSeuStatusDeveSerAGUARDANDO_APROVACAO()
        {
            Assert.Equal(EStatusTarefa.AGUARDANDO_APROVACAO, _folhaDePonto.Status);
        }
        [Fact]
        public void DadoUmaTarefaAprovadaSeuStatusDeveSerAPROVADO()
        {
            _folhaDePonto.AprovarTarefa();
            Assert.Equal(EStatusTarefa.APROVADO, _folhaDePonto.Status);
        }
        [Fact]
        public void DadoUmaTarefaReprovadaSeuStatusDeveSerREPROVADO()
        {
            _folhaDePonto.ReprovarTarefa();
            Assert.Equal(EStatusTarefa.REPROVADO, _folhaDePonto.Status);
        }
    }
}
