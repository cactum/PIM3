using Microsoft.AspNetCore.Mvc.Rendering;

namespace PIM3.Models
{
    public class ConsultaHoleriteModel
    {       
        public List<FuncionarioModel> Funcionarios { get; set; } 
        public FuncionarioModel Funcionario { get; set; }
        public ConsultaHoleriteModel Holerite { get; set; }
        public List<SelectListItem> Meses { get; set; }
        public List<SelectListItem> Anos { get; set; }
        public List<HoleriteModel> Holerites { get; set; }

    }
}
