
namespace TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Outputs
{
    using TimeSheet.Shared.Commands;
    public class ReprovarFolhaPontoCommandResult : ICommandResult
    {
        public ReprovarFolhaPontoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
