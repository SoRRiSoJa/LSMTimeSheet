namespace TimeSheet.Shared.Commands
{
    public interface ICommandResult
    {
        public interface ICommandResult
        {
            bool Success { get; set; }
            string Message { get; set; }
            object Data { get; set; }
        }
    }
}
