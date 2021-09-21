using FluentValidator;
using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.Commands.ProjetoCommands.Inputs
{
    using TimeSheet.Shared.Commands;
    public class CriarProjetoCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid Responsavel { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
              .Requires()
              .IsNotNull(Responsavel, "Responsavel", "Você deve indicar o responsável do projeto")
              .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(Nome, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
              .HasMinLen(Descricao, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
              .HasMaxLen(Descricao, 40, "Sobrenome", "O sobrenome deve conter no máximo 40 caracteres")
          );
            return !Invalid;
        }
    }
}
