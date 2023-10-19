namespace PIM3.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public  string Nome { get; set; }
        public DateTime NascData  { get; set; }   
        public char Genero { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAdmissao { get; set; }


    }
}
