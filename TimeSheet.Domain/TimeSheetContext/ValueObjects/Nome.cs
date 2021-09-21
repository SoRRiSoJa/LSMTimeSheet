using FluentValidator;
using FluentValidator.Validation;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            AddNotifications(new ValidationContract()
               .Requires()
               .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O nome deve conter pelo menos 3 caracteres")
               .HasMaxLen(PrimeiroNome, 40, "PrimeiroNome", "O nome deve conter no máximo 40 caracteres")
               .HasMinLen(Sobrenome, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
               .HasMaxLen(Sobrenome, 40, "Sobrenome", "O sobrenome deve conter no máximo 40 caracteres")
           );
        }
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string NomeCompleto { get { return $"{ PrimeiroNome} {Sobrenome}"; } }
    }
}
