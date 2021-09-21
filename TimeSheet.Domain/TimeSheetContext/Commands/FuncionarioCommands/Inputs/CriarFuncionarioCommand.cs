using FluentValidator;
using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.Commands.FuncionarioCommands.Inputs
{
    using TimeSheet.Domain.TimeSheetContext.Enums;
    using TimeSheet.Shared.Commands;

    public class CriarFuncionarioCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string DDD { get; set; }
        public string Siafi { get; set; }
        public string DDI { get; set; }
        public string Numero { get; set; }
        public string EmailURI { get; set; }
        public string NumeroDocumento { get; set; }
        public ETipoDocumento Tipo { get; set; }
        public ECategoriaFuncionario CategoriaFuncionario { get; set; }
        public Guid Usuario { get; set; }
        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
              .Requires()
              .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(PrimeiroNome, 40, "PrimeiroNome", "O nome deve conter no máximo 40 caracteres")
              .HasMinLen(Sobrenome, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
              .HasMaxLen(Sobrenome, 40, "Sobrenome", "O sobrenome deve conter no máximo 40 caracteres")
              .IsEmail(EmailURI, "Email", "O E-mail é inválido")
              .IsNotNull(Usuario, "Usuario", "Voc~e deve fornecer o id do usuário para o funcionario.")
            );
            return !Invalid;
        }
    }
}
