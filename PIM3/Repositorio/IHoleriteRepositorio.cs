using PIM3.Models;

namespace PIM3.Repositorio
{
    public interface IHoleriteRepositorio
    {
        List<FuncionarioModel> BuscarTodos();
        List<FuncionarioModel> Buscar();
        List<HoleriteModel> ConsultarHolerites(int funcionarioId);
        FuncionarioModel ListarPorId(int id);
        HoleriteModel BuscarPorId(int id);
     


    }
}
