using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    [Route("Usuario")]
    public class PessoaController : Controller
    {
        [Route("Inicio")]
        public IActionResult Index()
        {
            ViewBag.Mensagem = TempData["TextoParaAIndex"];
            return View();
        }
        
        [Route("Detalhes/{id:int}")]
        public IActionResult DetalhesUsuario(int id)
        {
            //ViewBag.TextoTelaDetalhes = "Texto para a tela de detalhes.";
            //ViewBag.DataAtual = DateTime.Now;

            //ViewData["TextoTelaDetalhes"] = "Texto para a tela de detalhes.";
            //ViewData["DataAtual"] = DateTime.Now;

            TempData["TextoParaAIndex"] = "Texto que vai aparecer na Index de Pessoa.";

            return RedirectToAction("Index");
        }

        [Route("UsuarioUrl")]
        public IActionResult UsuarioUrl(string nome, string sobrenome)
        {
            return View("UsuarioUrl",$"{nome} {sobrenome}");
        }

        [HttpGet]
        [Route("CriarUsuario")]
        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        [Route("CriarUsuario")]
        public IActionResult CriarUsuario(string nome, string sobrenome)
        {
            return View("UsuarioUrl",$"{nome} {sobrenome}");
        }
    }
}
