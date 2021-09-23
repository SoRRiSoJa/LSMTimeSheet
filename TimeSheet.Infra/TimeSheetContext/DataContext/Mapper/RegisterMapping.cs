using Dapper.FluentMap;

namespace TimeSheet.Infra.TimeSheetContext.DataContext.Mapper
{
    public static class RegisterMapping
    {
        public static void Register()
        {
            FluentMapper.Initialize((config) =>
            {
                config.AddMap(new UsuarioMap());
            });
        }
    }
}
