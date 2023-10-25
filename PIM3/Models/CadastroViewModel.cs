using System.ComponentModel.DataAnnotations;

namespace PIM3.Models
{
    public class CadastroViewModel 
    {
        public List<FuncaoModel>? Funcoes { get; set; }
        public FuncionarioModel? Funcionario { get; set; }
       

        // public DadosBancoModel? DadosBancarios { get; set; }
    }
}