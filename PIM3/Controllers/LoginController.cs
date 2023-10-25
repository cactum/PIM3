using Microsoft.AspNetCore.Mvc;
using PIM3.Models;

namespace PIM3.Controllers
{
    public class LoginController : Controller
    {
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
                    return RedirectToAction("Index", "Home");
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
