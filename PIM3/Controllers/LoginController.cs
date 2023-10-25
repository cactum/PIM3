using Microsoft.AspNetCore.Mvc;
using PIM3.Models;
using PIM3.Repositorio;

namespace PIM3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (@ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha invaálida.";
                    }

                    TempData["MensagemErro"] = $"Login e/ou Senha invaálido(s).";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel logar, tente novamente! \n" +
                   $"detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
