namespace TimeSheet.Domain.TimeSheetContext.Entities
{
    using System.Collections.Generic;
    using TimeSheet.Domain.TimeSheetContext.Enums;
    using TimeSheet.Domain.TimeSheetContext.ValueObjects;
    using TimeSheet.Shared.Entities;

    public class Funcionario : Entity
    {
        private readonly IList<Projeto> _projetos;

        public Funcionario()
        {
            Endereco = new Endereco();
            _projetos = new List<Projeto>();
        }
        public Funcionario(Nome nome, Endereco endereco, Telefone telefone, Email email, Documento documento, Usuario usuario, ECategoriaFuncionario categoria)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Documento = documento;
            Usuario = usuario;
            Categoria = categoria;
        }

        public Nome Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public Documento Documento { get; private set; }
        public Usuario Usuario { get; private set; } = new Usuario();
        public ECategoriaFuncionario Categoria { get; private set; }

        public void AdicionarProjeto(Projeto proj)
        {
            _projetos.Add(proj);
        }
    }
}
