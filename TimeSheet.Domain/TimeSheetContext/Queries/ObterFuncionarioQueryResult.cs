using System;

namespace TimeSheet.Domain.TimeSheetContext.Queries
{
    using TimeSheet.Domain.TimeSheetContext.Entities;
    using TimeSheet.Domain.TimeSheetContext.Enums;

    public class ObterFuncionarioQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string DDD { get; private set; }
        public string Siafi { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public Usuario Usuario { get; set; }
        public ECategoriaFuncionario Categoria { get; private set; }
    }
}
