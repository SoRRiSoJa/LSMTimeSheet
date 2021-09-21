using TimeSheet.Shared.Commands;

namespace TimeSheet.Domain.TimeSheetContext.Commands.FolhaPontoCommands.Outputs
{
    public class AprovarFolhaPontoCommandResult : ICommandResult
    {
        public AprovarFolhaPontoCommandResult(bool success, string message, object data)
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
