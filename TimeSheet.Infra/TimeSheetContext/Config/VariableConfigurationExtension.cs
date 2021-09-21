using System;

namespace TimeSheet.Infra.TimeSheetContext.Config
{
    public static class VariableConfigurationExtension
    {

        public static string GetVariable(string name)
        {
            var variable = Environment.GetEnvironmentVariable(name);
            return variable ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
