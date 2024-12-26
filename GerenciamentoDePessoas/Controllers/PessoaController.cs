using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    [Route("Usuario")]
    public class PessoaController : Controller
    {
        [Route("Inicio")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("Detalhes/{id:int}")]
        public IActionResult DetalhesUsuario(int id)
        {
            return View();
        }
    }
}
