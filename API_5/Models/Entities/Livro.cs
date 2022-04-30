using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_5.Models.Entities
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O {0} não pode ultrapassar 200 caracteres.")]
        public string Nome { get; set; }

        public string Edicao { get; set; }

        [Range(1, int.MaxValue, ErrorMessage =" O {0} da página deve estar entre {1} e {2}")]
        public int NumeroPagina { get; set; }

        public decimal Preco { get; set; }

        [Required(ErrorMessage ="Necessário informar a {0} do livro.")]
        public string Editora { get; set; }

        [Url(ErrorMessage ="O campo {0} necessita de uma URL válida.")]
        public string SiteLivro { get; set; }

        [EmailAddress(ErrorMessage ="Necessário um {0} válido!")]
        public string EmailAutor { get; set; }
    }
}