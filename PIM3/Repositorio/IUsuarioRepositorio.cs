using PIM3.Models;

namespace PIM3.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
