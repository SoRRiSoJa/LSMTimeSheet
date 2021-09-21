using FluentValidator;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    public class Telefone : Notifiable
    {
        public Telefone(string dDI, string dDD, string numero)
        {
            DDI = dDI;
            DDD = dDD;
            Numero = numero;
        }

        public string DDI { get; private set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public string NumeroFromatado { get { return $"+{DDI} ({DDD}) - {Numero}"; } }

        public override string ToString()
        {
            return $"+{DDI} ({DDD}) - {Numero}";
        }
    }
}
