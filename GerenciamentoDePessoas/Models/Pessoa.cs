using GerenciamentoDePessoas.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDePessoas.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
        }

        public Pessoa(int id, string nome, string sobrenome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite um nome")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite um sobrenome")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [CustomValidation(typeof(Pessoa), "ValidarDataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 digitos sem caracters especiais.")]
        public string CPF { get; set; }

        [Range(1, 8, ErrorMessage = "Selecione um tipo sanguíneo válido.")]
        public ETipoSanguineo TipoSanguineo { get; set; }

        public static ValidationResult ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento > DateTime.Now)
            {

                return new ValidationResult("A data de nascimento não pode ser futura.");
            }

            return ValidationResult.Success;
        }
    }
}
