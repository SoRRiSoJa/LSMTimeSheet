using FluentValidator;
using Newtonsoft.Json;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    public class Endereco : Notifiable
    {
        public Endereco()
        {

        }
        public Endereco(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string dDD, string siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            DDD = dDD;
            Siafi = siafi;
        }
        [JsonProperty("cep")]
        public string Cep { get; private set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; private set; }
        [JsonProperty("complemento")]
        public string Complemento { get; private set; }
        [JsonProperty("bairro")]
        public string Bairro { get; private set; }
        [JsonProperty("localidade")]
        public string Localidade { get; private set; }
        [JsonProperty("uf")]
        public string Uf { get; private set; }
        [JsonProperty("ibge")]
        public string Ibge { get; private set; }
        [JsonProperty("gia")]
        public string Gia { get; private set; }
        [JsonProperty("ddd")]
        public string DDD { get; private set; }
        [JsonProperty("siafi")]
        public string Siafi { get; private set; }
        public override string ToString()
        {
            return $" {Logradouro} - { Localidade } - {Uf} - {Cep} ";
        }
    }
}
