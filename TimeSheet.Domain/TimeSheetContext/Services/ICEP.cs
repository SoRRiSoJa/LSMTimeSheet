using System.Threading.Tasks;
using TimeSheet.Domain.TimeSheetContext.ValueObjects;

namespace TimeSheet.Domain.TimeSheetContext.Services
{
    public interface ICEP
    {
        Task<Endereco> Obter(string cep);
    }
}
