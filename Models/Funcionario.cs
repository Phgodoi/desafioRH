namespace desafioRH.Models
{
    public class Funcionario
    {
        public Funcionario() { }

        public Funcionario(int id, string nome, string endereco, string ramal, string emailCorporativo, string departamento, decimal salario, DateTimeOffset? dataAdimissao)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Ramal = ramal;
            EmailCorporativo = emailCorporativo;
            Departamento = departamento;
            Salario = salario;
            DataAdmissao = dataAdimissao;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Ramal { get; set;}
        public string EmailCorporativo { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTimeOffset? DataAdmissao { get; set; }
        

    }
}
