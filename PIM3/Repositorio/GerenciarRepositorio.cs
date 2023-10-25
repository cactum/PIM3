using PIM3.Data;
using PIM3.Models;
using System.Globalization;

namespace PIM3.Repositorio
{
    public class GerenciarRepositorio : IGerenciarRepositorio
    {
        private readonly BancoContext _bancoContext;
        public GerenciarRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FuncionarioModel AdicionarFuncionario(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionario.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
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
        public List<FuncionarioModel> PesquisarPorCpfPrefix(string cpfPrefix)
        {
            return _bancoContext.Funcionario.Where(x => x.CPF.StartsWith(cpfPrefix)).ToList();
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
            FuncionarioModel funcionarioDB = ListarPorId(funcionario.Id);
            if (funcionarioDB == null) throw new System.Exception("Houve um erro na atualização do cadastro");
            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.CPF = funcionario.CPF;
            funcionarioDB.NascData = funcionario.NascData;
            funcionarioDB.Telefone = funcionario.Telefone;
            funcionarioDB.Endereco = funcionario.Endereco;
            funcionarioDB.Genero = funcionario.Genero;
            funcionarioDB.DataAdmissao= funcionario.DataAdmissao;

            _bancoContext.Funcionario.Update(funcionarioDB);
            _bancoContext.SaveChanges();

            return funcionarioDB;
        }
        public bool Apagar(int id)
        {
            FuncionarioModel FuncionarioDB = ListarPorId(id);

            if (FuncionarioDB == null) throw new System.Exception("Erro ao deletar cadastro");

            _bancoContext.Funcionario.Remove(FuncionarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
