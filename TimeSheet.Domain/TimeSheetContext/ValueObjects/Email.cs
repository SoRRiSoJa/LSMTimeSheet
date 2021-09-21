using FluentValidator;
using FluentValidator.Validation;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string emailURI)
        {
            EmailURI = emailURI;
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(EmailURI, "Email", "O E-mail é inválido")
            );
        }

        public string EmailURI { get; private set; }

    }
}
