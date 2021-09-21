using FluentValidator;
using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    public class Periodo : Notifiable
    {
        public Periodo(DateTime inicioAtividade, DateTime fimAtividade)
        {
            InicioAtividade = inicioAtividade;
            FimAtividade = fimAtividade;
            AddNotifications(new ValidationContract()
               .IsTrue(Validar(InicioAtividade, FimAtividade), "Periodo", "Verifique os horários de inicio e fim, o intervalo não pode ser maior que 24 Horas")
               );
        }

        public DateTime InicioAtividade { get; private set; }
        public DateTime FimAtividade { get; private set; }
        public TimeSpan Intervalo { get { return FimAtividade.Subtract(InicioAtividade); } }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", Convert.ToInt64(Intervalo.TotalHours), Intervalo.Minutes, Intervalo.Seconds); ;
        }
        private static bool Validar(DateTime ini, DateTime fim) => ini.CompareTo(fim) < 0 && fim.Subtract(ini).TotalHours <= 24;

    }
}
