using FluentValidator;
using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Inputs
{
    using TimeSheet.Shared.Commands;
    public class CriarFolhaPontoCommand : Notifiable, ICommand
    {
        public Guid Projeto { get; set; }
        public Guid Funcionario { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
               .Requires()
                .HasMinLen(Descricao, 3, "Descricao", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 80, "Descricao", "A descrição deve deve conter no máximo 80 caracteres")
               );
            return !Invalid;
        }
    }
}
