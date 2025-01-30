using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _context;

        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _context = context;
        }

        public async Task Apagar(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> BuscarPessoasNome(string termo)
        {
            var pessoasDb = await _context.Pessoas
            .Where(p => EF.Functions.Like(p.Nome, $"%{termo}%") ||
                        EF.Functions.Like(p.Sobrenome, $"%{termo}%") ||
                        EF.Functions.Like(p.CPF, $"%{termo}%"))
            .ToListAsync();

            return pessoasDb;

        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            try
            {
                var pessoaDb = await _context.Pessoas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (pessoaDb == null) 
                {
                    throw new Exception("Pessoa não encontrada.");
                }

                return pessoaDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _context.Pessoas.ToListAsync();

            return usuariosBanco;
        }

        public async Task<int> BuscarTotal()
        {
            return await _context.Pessoas.CountAsync();
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            var pessoas = new List<Pessoa>
    {
        new Pessoa { Nome = "João", Sobrenome = "Silva", DataNascimento = new DateTime(1990, 5, 15), CPF = "12345678901", TipoSanguineo = ETipoSanguineo.APositivo },
        new Pessoa { Nome = "Maria", Sobrenome = "Oliveira", DataNascimento = new DateTime(1985, 3, 10), CPF = "23456789012", TipoSanguineo = ETipoSanguineo.BPositivo },
        new Pessoa { Nome = "Carlos", Sobrenome = "Santos", DataNascimento = new DateTime(1978, 8, 25), CPF = "34567890123", TipoSanguineo = ETipoSanguineo.ONegativo },
        new Pessoa { Nome = "Ana", Sobrenome = "Souza", DataNascimento = new DateTime(1992, 12, 30), CPF = "45678901234", TipoSanguineo = ETipoSanguineo.ABNegativo },
        new Pessoa { Nome = "Pedro", Sobrenome = "Costa", DataNascimento = new DateTime(2000, 1, 1), CPF = "56789012345", TipoSanguineo = ETipoSanguineo.ANegativo },
        new Pessoa { Nome = "Lucas", Sobrenome = "Ferreira", DataNascimento = new DateTime(1995, 7, 20), CPF = "67890123456", TipoSanguineo = ETipoSanguineo.BNegativo },
        new Pessoa { Nome = "Juliana", Sobrenome = "Martins", DataNascimento = new DateTime(1989, 11, 5), CPF = "78901234567", TipoSanguineo = ETipoSanguineo.ABPositivo },
        new Pessoa { Nome = "Fernando", Sobrenome = "Lima", DataNascimento = new DateTime(1987, 4, 18), CPF = "89012345678", TipoSanguineo = ETipoSanguineo.APositivo },
        new Pessoa { Nome = "Paula", Sobrenome = "Gomes", DataNascimento = new DateTime(1993, 9, 12), CPF = "90123456789", TipoSanguineo = ETipoSanguineo.OPositivo },
        new Pessoa { Nome = "Thiago", Sobrenome = "Almeida", DataNascimento = new DateTime(1983, 6, 22), CPF = "01234567890", TipoSanguineo = ETipoSanguineo.ANegativo },
        new Pessoa { Nome = "Bruna", Sobrenome = "Carvalho", DataNascimento = new DateTime(1997, 10, 8), CPF = "12312312312", TipoSanguineo = ETipoSanguineo.ONegativo },
        new Pessoa { Nome = "Rafael", Sobrenome = "Ribeiro", DataNascimento = new DateTime(1991, 2, 14), CPF = "23423423423", TipoSanguineo = ETipoSanguineo.BPositivo },
        new Pessoa { Nome = "Larissa", Sobrenome = "Teixeira", DataNascimento = new DateTime(1994, 7, 3), CPF = "34534534534", TipoSanguineo = ETipoSanguineo.ABPositivo },
        new Pessoa { Nome = "André", Sobrenome = "Rocha", DataNascimento = new DateTime(1986, 5, 25), CPF = "45645645645", TipoSanguineo = ETipoSanguineo.ABNegativo },
        new Pessoa { Nome = "Camila", Sobrenome = "Barros", DataNascimento = new DateTime(1998, 8, 19), CPF = "56756756756", TipoSanguineo = ETipoSanguineo.BNegativo },
        new Pessoa { Nome = "Felipe", Sobrenome = "Pereira", DataNascimento = new DateTime(1990, 12, 29), CPF = "67867867867", TipoSanguineo = ETipoSanguineo.APositivo },
        new Pessoa { Nome = "Vanessa", Sobrenome = "Nascimento", DataNascimento = new DateTime(1982, 3, 17), CPF = "78978978978", TipoSanguineo = ETipoSanguineo.OPositivo },
        new Pessoa { Nome = "Rodrigo", Sobrenome = "Monteiro", DataNascimento = new DateTime(1988, 11, 2), CPF = "89089089089", TipoSanguineo = ETipoSanguineo.ONegativo },
        new Pessoa { Nome = "Priscila", Sobrenome = "Farias", DataNascimento = new DateTime(1999, 1, 27), CPF = "90190190190", TipoSanguineo = ETipoSanguineo.ANegativo },
        new Pessoa { Nome = "Eduardo", Sobrenome = "Dias", DataNascimento = new DateTime(1996, 6, 10), CPF = "01201201201", TipoSanguineo = ETipoSanguineo.BPositivo }
    };
            try
            {
                await _context.Pessoas.AddRangeAsync(pessoas);
                await _context.SaveChangesAsync();

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados: {ex.Message}");
            }

        }

        public async Task<Pessoa> Editar(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<bool> VerificarSePessoaExiste(string cpf)
        {
            var pessoaExiste = await _context.Pessoas.AnyAsync(x => x.CPF == cpf);

            return pessoaExiste;
        }
    }
}
