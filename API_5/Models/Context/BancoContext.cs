using API_5.Models.Entities;
using System.Data.Entity;

namespace API_5.Models.Context
{
    public class BancoContext : DbContext
    {
      public  DbSet<Livro> Livros { get; set; }
    }
}