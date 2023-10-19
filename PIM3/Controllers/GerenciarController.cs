using Microsoft.AspNetCore.Mvc;
using PIM3.Models;
using PIM3.Repositorio;

namespace PIM3.Controllers
{
    public class GerenciarController : Controller
    {
        private readonly IGerenciarRepositorio _gerenciarRepositorio;
        public GerenciarController(IGerenciarRepositorio gerenciarRepositorio)
        {
            _gerenciarRepositorio = gerenciarRepositorio;    
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListarTodos()
        {
            List<FuncionarioModel> funcionarios = _gerenciarRepositorio.Buscar();
            return View(funcionarios);
        }
        public IActionResult Editar(int id)
        {
            FuncionarioModel funcionario = _gerenciarRepositorio.ListarPorId(id);
            return View(funcionario);
        }
        [HttpGet]
        public IActionResult Criar()
        {
            var funcoes = _gerenciarRepositorio.BuscarTodos();
            var viewModel = new CadastroViewModel
            {
                Funcoes = funcoes,
                Funcionario = new FuncionarioModel(),

            };
            return View(viewModel);
        }
       
        [HttpPost]
        public IActionResult Criar(FuncionarioModel funcionario)
        {
            _gerenciarRepositorio.AdicionnarFuncionario(funcionario);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            _gerenciarRepositorio.Atualizar(funcionario);
            return RedirectToAction("Index");
        }
    }
}
