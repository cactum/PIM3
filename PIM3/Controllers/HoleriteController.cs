using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIM3.Data;
using PIM3.Models;
using PIM3.Repositorio;

namespace PIM3.Controllers
{
    public class HoleriteController : Controller
    {
        private readonly IHoleriteRepositorio _holeriteRepositorio;
        private readonly BancoContext _bancoContext;

        public HoleriteController(IHoleriteRepositorio holeriteRepositorio, BancoContext bancoContext)
        {
            _holeriteRepositorio = holeriteRepositorio;
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            try
            {
                List<FuncionarioModel> funcionarios = _holeriteRepositorio.Buscar();
                return View(funcionarios);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Algo saiu errado, não foi possivel localizar cadastros, tente novamente! \n" +
                    $"detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ConsultarHolerite()
        {
            // Aqui você pode preencher os valores de Meses e Anos para as opções do select no modelo.
            

            return View();
        }

        [HttpPost]
        public IActionResult DataReferencia(int FuncionarioId,ConsultaHoleriteModel model)
        {
            FuncionarioId = model.Funcionario.Id;
           
            if (ModelState.IsValid)
            {
               
                List<HoleriteModel> holerites = _holeriteRepositorio.ConsultarHolerites(FuncionarioId);

                // Você pode passar essa lista de 'holerites' para a View de resultado.
                return View("ResultadoConsulta", holerites);
            }

            // Se o modelo não for válido, retorne a View com os erros.
            return View(model);
        }


        public IActionResult DataReferencia(int id)
        {
            // Buscar o funcionário pelo ID
            FuncionarioModel funcionario = _holeriteRepositorio.ListarPorId(id);

            if (funcionario == null)
            {
                // Lógica para lidar com um funcionário inexistente
                return RedirectToAction("Index");
            }

            // Consultar holerites relacionados a esse funcionário usando o FuncionarioId
            List<HoleriteModel> holerites = _bancoContext.Holerites
                .Where(h => h.FuncionarioId == funcionario.Id)
                .ToList();

            var model = new ConsultaHoleriteModel
            {
                Funcionario = funcionario,
                Holerites = holerites,
                // Preencha os outros dados necessários no modelo
            };

            return View(model);
        }


        public List<SelectListItem> GetMeses()
        {
            var meses = new List<SelectListItem>
    {
        new SelectListItem("Janeiro", "01"),
        new SelectListItem("Fevereiro", "02"),
        new SelectListItem("Março", "03"),
        new SelectListItem("Abril","04"),
        new SelectListItem("Maio","05"),
        new SelectListItem("Junho","06"),
        new SelectListItem("Julho","07"),
        new SelectListItem("Agosto","08"),
        new SelectListItem("Setembro","09"),
        new SelectListItem("Outubro","10"),
        new SelectListItem("Novembro","11"),
        new SelectListItem("Dezembro","12"),
    };

            return meses;
        }

        public List<SelectListItem> GetAnos()
        {
            var anos = new List<SelectListItem>
    {
        new SelectListItem("2023", "2023"),
        new SelectListItem("2022", "2022"),
        new SelectListItem("2021", "2021"),
        new SelectListItem("2020", "2020"),
        new SelectListItem("2019", "2019"),

    };

            return anos;
        }


    }
}
