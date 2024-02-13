using System.Text.Json;

namespace desafioRH.Models
{
    public class FuncionarioLog : Funcionario
    {
        public FuncionarioLog() { }

        public FuncionarioLog(Funcionario funcionario, EnumTipoAcao? tipoAcao, string? jSON, DateTimeOffset? alteradoEm)
        {
            base.Id = funcionario.Id;
            base.Nome = funcionario.Nome;
            base.Ramal = funcionario.Ramal;
            base.Salario = funcionario.Salario;
            base.Endereco = funcionario.Endereco;
            base.Departamento = funcionario.Departamento;
            base.DataAdmissao = funcionario.DataAdmissao;
            base.EmailCorporativo = funcionario.EmailCorporativo;

            Id_Funcionario = funcionario.Id;
            TipoAcao = tipoAcao;
            JSON = JsonSerializer.Serialize(funcionario);
            AlteradoEm = alteradoEm;
        }

        public int Id { get; set; } 
        public int Id_Funcionario { get; set; } 
       
        public EnumTipoAcao? TipoAcao { get; set; }
        public string? JSON { get; set; }
        public DateTimeOffset? AlteradoEm { get; set; }
    }
}
