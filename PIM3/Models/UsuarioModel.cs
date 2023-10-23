using PIM3.Enums;
using System.ComponentModel.DataAnnotations;

namespace PIM3.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set;}
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set;}
        [Required(ErrorMessage = "Digite o email")]
        public string Email { get; set;}
        [Required(ErrorMessage = "selecione o perfil")]
        public PerfilEnum Perfil { get; set;}
        public DateTime DataCadastro { get; set;}
        public DateTime? DataAtualizacao { get; set;}
        public FuncionarioModel Funcionario { get; set; }

    }
}
