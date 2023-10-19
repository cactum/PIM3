using PIM3.Data;
using PIM3.Models;

namespace PIM3.Repositorio
{
    public class GerenciarRepositorio : IGerenciarRepositorio
    {
        private readonly BancoContext _bancoContext;
        public GerenciarRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FuncionarioModel AdicionnarFuncionario(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionario.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }
        public FuncionarioModel ListarPorId(int id)
        {
            return _bancoContext.Funcionario.FirstOrDefault(x => x.Id == id);
        }
        public List<FuncaoModel> BuscarTodos()
        {
            return _bancoContext.Funcao.ToList();
        }

        public List<FuncionarioModel> Buscar()
        {
            return _bancoContext.Funcionario.ToList();
        }

        public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            FuncionarioModel funcionarioDb = ListarPorId(funcionario.Id);
            if (funcionarioDb == null) throw new System.Exception("Houve um erro na atualização do cadastro");
            funcionarioDb.Nome = funcionario.Nome;
            funcionarioDb.CPF = funcionario.CPF;
            funcionarioDb.NascData = funcionario.NascData;
            funcionarioDb.Telefone = funcionario.Telefone;
            funcionarioDb.Endereco = funcionario.Endereco;
            funcionarioDb.Genero = funcionario.Genero;
            funcionarioDb.DataAdmissao= funcionario.DataAdmissao;

            _bancoContext.Funcionario.Update(funcionarioDb);
            _bancoContext.SaveChanges();

            return funcionarioDb;
        }
    }
}
