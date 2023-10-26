using PIM3.Models;

namespace PIM3.Helper
{
    public interface ISessao
    {

        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
