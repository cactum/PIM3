using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Principal;

namespace PIM3.Models
{
    public class HoleriteModel
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataReferencia { get; set; }
        public int HorasTrabalhadas { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Proventos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public decimal Descontos { get; set; }  
        public decimal IR { get; set; }
        public decimal INSS {get; set;}
        public decimal FGTS { get; set; }
        public decimal SalarioBruto { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
        public int FuncionarioId { get; set; }
        public FuncionarioModel Funcionario { get; set; }
       
    }

}


