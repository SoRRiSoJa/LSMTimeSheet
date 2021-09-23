using Dapper.FluentMap.Dommel.Mapping;

namespace TimeSheet.Infra.TimeSheetContext.DataContext.Mapper
{
    using TimeSheet.Domain.TimeSheetContext.Entities;

    public class UsuarioMap : DommelEntityMap<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Tb_Usuario");
            Map((x) => x.Id).ToColumn("Id_Usuario").IsKey();
            Map((x) => x.Login).ToColumn("Login");
            Map((x) => x.Senha).ToColumn("Senha");
            Map((x) => x.DataCriacao).ToColumn("DataCriacao");
            Map((x) => x.DataAlteracao).ToColumn("DataAlteracao");
            Map((x) => x.IsAtivo).ToColumn("Ativo");
        }
    }
}
