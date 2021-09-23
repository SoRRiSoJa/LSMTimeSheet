using System.Threading.Tasks;
using TimeSheet.Domain.TimeSheetContext.ValueObjects;

namespace TimeSheet.Domain.TimeSheetContext.Services
{
    public interface ICEPService
    {
        Task<Endereco> Obter(string cep);
    }
}
