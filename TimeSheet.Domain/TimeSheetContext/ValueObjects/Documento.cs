using FluentValidator;
using FluentValidator.Validation;

namespace TimeSheet.Domain.TimeSheetContext.ValueObjects
{
    using TimeSheet.Domain.TimeSheetContext.Enums;
    public class Documento : Notifiable
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;
            AddNotifications(new ValidationContract()
                .Requires().IsNotNull(Tipo, "Doumento", "Você deve especificar um tipo para o documnto")
                .IsTrue(Validar(Numero), "Documento", "Documento inválido")
            );
        }

        public string Numero { get; private set; }
        public ETipoDocumento Tipo { get; private set; }

        public bool Validar(string numero)
        {
            return (Tipo == ETipoDocumento.RG) ? ValidateRG(Numero) : ValidateCpf(Numero);
        }
        private bool ValidateRG(string rg) => (rg.Replace("-", "").Replace(".", "").Replace(",", "")).Length >= 9;
        private bool ValidateCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
