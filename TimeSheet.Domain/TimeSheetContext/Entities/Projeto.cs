using FluentValidator.Validation;
using System.Collections.Generic;
using System.Linq;

namespace TimeSheet.Domain.TimeSheetContext.Entities
{
    using TimeSheet.Shared.Entities;
    public class Projeto : Entity
    {
        private readonly IList<Funcionario> _equipeProjeto;

        public Projeto()
        {
            _equipeProjeto = new List<Funcionario>();
        }
        public Projeto(string nome, string descricao, Funcionario responsavel)
        {
            Nome = nome;
            Descricao = descricao;
            Responsavel = responsavel;
            _equipeProjeto = new List<Funcionario>();
            AddNotifications(new ValidationContract()
               .Requires()
               .IsNotNull(Responsavel, "Responsavel", "Você deve indicar o responsável do projeto")
               .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
               .HasMaxLen(Nome, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
               .HasMinLen(Descricao, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
               .HasMaxLen(Descricao, 40, "Sobrenome", "O sobrenome deve conter no máximo 40 caracteres")
           );
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Funcionario Responsavel { get; private set; } = new Funcionario();
        public IReadOnlyCollection<Funcionario> Equipe => _equipeProjeto.ToList();
        public void AdicionarFuncionario(Funcionario func)
        {
            _equipeProjeto.Add(func);
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
