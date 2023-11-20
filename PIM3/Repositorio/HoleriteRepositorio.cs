using PIM3.Data;
using PIM3.Models;
using System.Globalization;

namespace PIM3.Repositorio
{
    public class HoleriteRepositorio : IHoleriteRepositorio
    {
        private readonly BancoContext _bancoContext;
        public HoleriteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
    
        public FuncionarioModel ListarPorId(int id)
        {
            return _bancoContext.Funcionario.FirstOrDefault(x => x.Id == id);
        }
        public FuncionarioModel PesquisarCpf(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length >= 3)
            {
                // Pesquisa por qualquer parte do CPF
                return _bancoContext.Funcionario.FirstOrDefault(x => x.CPF.Contains(cpf));
            }
            else
            {
                // CPF com tamanho incorreto
                return null;
            }
        }
  
        public List<HoleriteModel> BuscarHoleritesFuncionario(string nome)
        {
            return _bancoContext.Holerites.ToList();
        }
        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionario.ToList();
        }
        public List<HoleriteModel> BuscarHolerites()
        {
            return _bancoContext.Holerites.ToList();
        }
        public List<FuncionarioModel> Buscar()
        {
            return _bancoContext.Funcionario.ToList();
        }

        public List<HoleriteModel> ConsultarHolerites(int funcionarioId)
        {
            var holerites = _bancoContext.Holerites
                .Where(h => h.FuncionarioId == funcionarioId)
                .ToList();

            return holerites;
        }

        public HoleriteModel BuscarPorId(int id)
        {
            return _bancoContext.Holerites.FirstOrDefault(x => x.Id == id);
        }



    }
}
