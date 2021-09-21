using Refit;
using System.Threading.Tasks;

namespace TimeSheet.Infra.TimeSheetContext.Services
{
    using TimeSheet.Domain.TimeSheetContext.Services;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    using TimeSheet.Infra.TimeSheetContext.Abstractions;

    public class CEPService : ICEP
    {
        public async Task<Endereco> Obter(string cep)
        {
            var cepClient = RestService.For<ICEPRefit>("https://viacep.com.br");

            var endereco = await cepClient.GetCEPAsync(cep);
            return endereco;
        }
    }
}
