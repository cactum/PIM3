using PIM3.Enums;
using System.ComponentModel.DataAnnotations;

namespace PIM3.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set;}
        public string Senha { get; set;}
        public string Email { get; set;}
        [Required(ErrorMessage = "Selecione o perfil do usuário")]
        public PerfilEnum? Perfil { get; set;}
        public DateTime DataCadastro { get; set;}
        public DateTime? DataAtualizacao { get; set;}
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
