using FluentValidator.Validation;
namespace TimeSheet.Domain.TimeSheetContext.Entities
{
    using TimeSheet.Shared.Entities;
    public class Usuario : Entity
    {
        public Usuario()
        {
        }

        public Usuario(string login, string senha)
        {

            Login = login;
            Senha = senha;
            AddNotifications(new ValidationContract()
              .Requires()
              .HasMinLen(Login, 3, "Login", "O nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(Login, 30, "Login", "O nome deve conter no máximo 40 caracteres")
              .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 digitos")
          );
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public override string ToString()
        {
            return Login;
        }
    }
}
