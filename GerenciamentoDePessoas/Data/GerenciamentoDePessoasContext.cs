using Microsoft.EntityFrameworkCore;
using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoDePessoasContext : IdentityDbContext<Usuario>
    {
        public GerenciamentoDePessoasContext (DbContextOptions<GerenciamentoDePessoasContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var administrador = new IdentityRole("administrador");
            administrador.NormalizedName = "ADMINISTRADOR";

            var operador = new IdentityRole("operador");
            operador.NormalizedName = "OPERADOR";

            builder.Entity<IdentityRole>().HasData(administrador, operador);


            base.OnModelCreating(builder);
        }
    }
}
