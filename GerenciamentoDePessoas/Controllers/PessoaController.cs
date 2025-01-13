﻿using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    [Route("Usuario")]
    public class PessoaController : Controller
    {
        [Route("Inicio")]
        public IActionResult Index()
        {
            ViewBag.Cadastro = TempData["SucessoCriacao"];
            return View();
        }

        [Route("Detalhes/{id:int}")]
        public IActionResult DetalhesUsuario(int id)
        {
            ViewData["TextoDescricao"] = "Texto da tela de descrição.";
            ViewData["DataAtual"] = DateTime.Now;

            TempData["SucessoRedirecionamento"] = "O redirecionamento fui um sucesso!";


            var listaUsuario = new List<Pessoa>();
            listaUsuario.Add(new Pessoa(1, "Pedro", "Silva", DateTime.Now));
            listaUsuario.Add(new Pessoa(2, "Maria", "Silva", DateTime.Now));
            listaUsuario.Add(new Pessoa(3, "Rosa", "Mendes", DateTime.Now));
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("BuscaPorUrl")]
        public IActionResult BuscaPorUrl(string nome, string sobrenome)
        {
            var listaUsuario = new List<Pessoa>();
            listaUsuario.Add(new Pessoa(1, "Pedro", "Silva", DateTime.Now));
            listaUsuario.Add(new Pessoa(2, "Maria", "Silva", DateTime.Now));
            listaUsuario.Add(new Pessoa(3, "Rosa", "Mendes", DateTime.Now));

            Pessoa pessoaSelecionada = listaUsuario.FirstOrDefault(n => n.Nome == nome && n.Sobrenome == sobrenome);

            return View(pessoaSelecionada);
        }

        [HttpGet]
        [Route("CriarUsuario")]
        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        [Route("CriarUsuario")]
        public IActionResult CriarUsuario(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                TempData["SucessoCriacao"] = $"O usuário {pessoa.Nome} {pessoa.Sobrenome} foi criado!";
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }
    }
}
