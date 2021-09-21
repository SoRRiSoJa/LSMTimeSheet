using FluentValidator;
using FluentValidator.Validation;

namespace TimeSheet.Domain.TimeSheetContext.Commands.UsuarioCommands.Inputs
{
    using TimeSheet.Shared.Commands;
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
              .Requires()
              .HasMinLen(Login, 3, "Login", "O nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(Login, 30, "Login", "O nome deve conter no máximo 40 caracteres")
              .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 digitos")
          );
            return !Invalid;
        }
    }
}
