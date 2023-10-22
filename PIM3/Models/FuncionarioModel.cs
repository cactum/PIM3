using System.ComponentModel.DataAnnotations;

namespace PIM3.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public  string? Nome { get; set; }
        [Required(ErrorMessage = "Digite a data de nascimento")]
        public DateTime NascData  { get; set; }
        [Required(ErrorMessage = "Digite o genero")]
        public char Genero { get; set; }
        [Required(ErrorMessage = "Digite o cpf")]
        public string? CPF { get; set; }
        [Required(ErrorMessage = "Digite o endereço")]
        public string? Endereco { get; set; }
        [Required(ErrorMessage = "Digite o telefone")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Digite a data de contato")]
        public DateTime DataAdmissao { get; set; }


    }
}
