using FluentValidator;
using FluentValidator.Validation;
using System;

namespace TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Inputs
{
    using TimeSheet.Shared.Commands;

    class ReprovarFolhaPontoCommand : Notifiable, ICommand
    {
        public Guid Projeto { get; set; }
        public Guid Responsavel { get; set; }
        public Guid FolhaPonto { get; set; }
        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
              .Requires()
               .IsNotNull(Projeto, "Projeto", "Você deve indicar um projeto a ser aprovado")
               .IsNotNull(Responsavel, "Responsavel", "Você deve indicar o responsavel pela aprovação")
               .IsNotNull(FolhaPonto, "FolhaPonto", "Você deve indicar a atividade a ser aprovada.")
              );
            return !Invalid;
        }
    }
}
