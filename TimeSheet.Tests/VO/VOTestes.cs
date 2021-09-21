using System;
using Xunit;

namespace TimeSheet.VO.Tests
{
    using TimeSheet.Domain.TimeSheetContext.Enums;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    public class VOTestes
    {
        private readonly Nome _nomeVo;
        private readonly Telefone _telefoneVo;
        private readonly Email _emailVo;
        private readonly Email _emailInvalidoVo;
        private readonly Documento _documentoRGVo;
        private readonly Documento _documentoCPFVo;
        private readonly Periodo _periodo;
        private readonly Endereco _enderecoVo;

        public VOTestes()
        {
            _nomeVo = new Nome("João André", "Martins Dias e Silva");
            _telefoneVo = new Telefone("55", "18", "981225687");
            _emailVo = new Email("jamdes@hotmail.com");
            _emailInvalidoVo = new Email("jamdes2hotmail.com");
            _documentoRGVo = new Documento("30.065.841-2", ETipoDocumento.RG);
            _documentoCPFVo = new Documento("218.551.898-44", ETipoDocumento.CPF);
            _periodo = new Periodo(DateTime.Now, DateTime.Now.AddMinutes(30));
            _enderecoVo = new Endereco("19000-000", "Joao Lopes de Oliveira 168", "", "Centro", "Presidente Venceslau", "SP", "", "", "18", "");
        }
        [Fact]
        public void DadoUmNomeESobrenomeDevoTerUmNomeCompleto()
        {
            Assert.Equal("João André Martins Dias e Silva", _nomeVo.NomeCompleto);
        }
        [Fact]
        public void DadoUmDdiDddENumeroDevoTerUmTelefoneCompleto()
        {

            Assert.Equal("+55 (18) - 981225687", _telefoneVo.NumeroFromatado);
        }
        [Fact]
        public void DadoUmEMailValidoDevoObterUmemail()
        {

            Assert.False(_emailVo.Invalid);
        }
        [Fact]
        public void DadoUmEMailInvalidoDevoObterEmailInvalido()
        {
            Assert.True(_emailInvalidoVo.Invalid);
        }
        [Fact]
        public void DadoUmCPFInvalidoDevoTerUmaValidacaoNegativa()
        {
            var documentolVo = new Documento("218.559.881-58", ETipoDocumento.CPF);
            Assert.True(documentolVo.Invalid);

        }
        [Fact]
        public void DadoUmCPFValidoDevoTerUmaValidacaoPositiva()
        {
            Assert.False(_documentoCPFVo.Invalid);
        }
        [Fact]
        public void DadoUmRGValidoDevoTerUmaValidacaoPositiva()
        {
            Assert.False(_documentoRGVo.Invalid);
        }
        [Fact]
        public void DadoUmRGInvalidoDevoTerUmaValidacaoNegativa()
        {
            var documentolVo = new Documento("30.065.841", ETipoDocumento.RG);
            Assert.True(documentolVo.Invalid);

        }
        [Fact]
        public void DadoUmaAtividadeValidaDevoTerUmaValidacaoPositiva()
        {
            Assert.False(_periodo.Invalid);
        }
        [Fact]
        public void DadoUmPeriodoValidoDevoTerUmaavaliaçãoPositiva()
        {
            var data = DateTime.Now;
            var inicio = data;
            var fim = inicio.AddHours(22);
            var periodo = new Periodo(inicio, fim);
            Assert.False(periodo.Invalid);
        }
        [Fact]
        public void DadoUmaEnderecoValidaDevoTerUmaValidacaoPositiva()
        {
            Assert.False(_enderecoVo.Invalid);
        }
    }
}
