using PIM3.Models;

namespace PIM3.Repositorio
{
    public interface IGerenciarRepositorio
    {
        FuncionarioModel AdicionnarFuncionario(FuncionarioModel funcionario);
        FuncionarioModel ListarPorId(int id);
        List<FuncaoModel> BuscarTodos();
        List<FuncionarioModel> Buscar();
        FuncionarioModel Atualizar(FuncionarioModel funcionario);
    }
}
