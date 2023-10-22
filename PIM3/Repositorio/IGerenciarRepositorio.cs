using PIM3.Models;

namespace PIM3.Repositorio
{
    public interface IGerenciarRepositorio
    {
        FuncionarioModel AdicionarFuncionario(FuncionarioModel funcionario);
        FuncionarioModel ListarPorId(int id);
        FuncionarioModel PesquisarCpf(string  cpf);
        List<FuncaoModel> BuscarTodos();
        List<FuncionarioModel> Buscar();
        FuncionarioModel Atualizar(FuncionarioModel funcionario);
        bool Apagar(int id);
    }
}
