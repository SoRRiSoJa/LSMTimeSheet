using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.Entities
{
    using TimeSheet.Domain.TimeSheetContext.Enums;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    using TimeSheet.Shared.Entities;
    public class FolhaPonto : Entity
    {
        public FolhaPonto(Projeto projeto, Funcionario funcionario, DateTime data, Periodo periodo, string identificador, string descricao)
        {
            Data = data;
            Identificador = identificador;
            Descricao = descricao;
            Funcionario = funcionario;
            Projeto = projeto;
            Periodo = periodo;
            Status = EStatusTarefa.AGUARDANDO_APROVACAO;
            AddNotifications(new ValidationContract()
               .Requires()
               .IsNotNull(Projeto, "Projeto", "Você deve informar o funcionário que realizou a atividade")
               .IsNotNull(Funcionario, "Funcionario", "Você deve informar o projeto para a atividade")
               .IsTrue(Validar(Data), "Data", "A data de lançamento não pode ser de um ano diferente do atual.")
               .IsNotNull(Periodo, "Periodo", "Você deve informar um periodo válido.")
                .HasMinLen(Descricao, 3, "Descricao", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 80, "Descricao", "A descrição deve deve conter no máximo 80 caracteres")
               );
        }

        public Projeto Projeto { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public DateTime Data { get; private set; }
        public Periodo Periodo { get; private set; }
        public string Identificador { get; private set; }
        public string Descricao { get; private set; }

        public EStatusTarefa Status { get; private set; }

        public void AprovarTarefa()
        {
            if (!this.Invalid)
                Status = EStatusTarefa.APROVADO;
        }
        public void ReprovarTarefa()
        {
            if (!this.Invalid)
                Status = EStatusTarefa.REPROVADO;
        }
        private static bool Validar(DateTime dataAtividade) => dataAtividade.Year == DateTime.Now.Year;
    }
}
