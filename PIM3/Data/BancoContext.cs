using Microsoft.EntityFrameworkCore;
using PIM3.Models;

namespace PIM3.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        
        public DbSet<FuncionarioModel> Funcionario { get; set; }
        public DbSet<FuncaoModel> Funcao { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
