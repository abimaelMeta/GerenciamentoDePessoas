using Microsoft.EntityFrameworkCore;
using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoDePessoasContext : DbContext
    {
        public GerenciamentoDePessoasContext (DbContextOptions<GerenciamentoDePessoasContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; } = default!;
    }
}
