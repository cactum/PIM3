using Microsoft.AspNetCore.Mvc;

namespace PIM3.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
