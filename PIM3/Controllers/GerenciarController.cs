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
            try
            {
                List<FuncionarioModel> funcionarios = _gerenciarRepositorio.Buscar();
                return View(funcionarios);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel localizar cadastros, tente novamente! \n" +
                    $"detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Pesquisar([FromQuery(Name = "CPF")] string cpf)
        {
            try
            {
                List<FuncionarioModel> funcionarios = new List<FuncionarioModel>();

                // Verifique se o CPF não está vazio
                if (!string.IsNullOrEmpty(cpf))
                {
                    // 1. Pesquise por parte do CPF (três primeiros dígitos)
                    string cpfPrefix = cpf.Substring(0, 3);
                    var funcionariosCpfPrefix = _gerenciarRepositorio.PesquisarPorCpfPrefix(cpfPrefix);
                    funcionarios.AddRange(funcionariosCpfPrefix);

                    // 2. Se não encontrar resultados nos três primeiros dígitos, pesquise por CPF completo
                    if (funcionariosCpfPrefix.Count == 0)
                    {
                        var funcionarioCpfCompleto = _gerenciarRepositorio.PesquisarCpf(cpf);
                        if (funcionarioCpfCompleto != null)
                        {
                            funcionarios.Add(funcionarioCpfCompleto);
                        }
                    }
                }

                return View(funcionarios);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Algo saiu errado, não foi possível localizar cadastros, tente novamente! \n" +
                    $"Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            try
            {
                FuncionarioModel funcionario = _gerenciarRepositorio.ListarPorId(id);
                return View(funcionario);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel localizar, tente novamente! \n" +
                 $"detalhe do erro: {e.Message}";
                return RedirectToAction("ListarTodos");
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    _gerenciarRepositorio.AdicionarFuncionario(funcionario);
                    TempData["MensagemSucesso"] = "Cadastrado realizado com sucesso";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel cadastrar, tente novamente! \n" +
                $"detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            try
            {
                _gerenciarRepositorio.Atualizar(funcionario);
                TempData["MensagemSucesso"] = "Cadastro atualizado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel alterar, tente novamente! \n" +
                $"detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _gerenciarRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cadastro apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel apagar, tente novamente!";
                }

                return RedirectToAction("ListarTodos");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel apagar, tente novamente! \n" +
                   $"detalhe do erro: {erro.Message}";
                return RedirectToAction("ListarTodos");
            }
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            FuncionarioModel funcionario = _gerenciarRepositorio.ListarPorId(id);
            return View(funcionario);
        }
    }
}
