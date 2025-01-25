﻿using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodos();
        Task<Pessoa> Criar(Pessoa pessoa);
        Task<Pessoa> BuscarPorId(int id);
        Task<Pessoa> Editar(Pessoa pessoa);
        Task Apagar(int id);
    }
}
