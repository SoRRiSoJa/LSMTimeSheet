using Refit;
using System.Threading.Tasks;

namespace TimeSheet.Infra.TimeSheetContext.Abstractions
{
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    public interface ICEPRefit
    {
        [Get("/ws/{cep}/json")]
        Task<Endereco> GetCEPAsync(string cep);
    }
}
