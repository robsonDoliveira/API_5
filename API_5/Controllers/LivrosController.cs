using API_5.Models.Context;
using API_5.Models.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace API_5.Controllers
{
    public class LivrosController : ApiController
    {
        BancoContext db = new BancoContext();

        // POST - ENVIAR
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livros.Add(livro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = livro.Codigo }, livro);
        }

        // GET - RETORNAR
        public IHttpActionResult GetLivros(int pagina = 1, int qtdItems = 10)
        {
            // PAGINAÇÃO
            if (pagina < 1 || qtdItems < 1)
                return BadRequest("Os parâmetros [página] e [QtdItems] devem ser maiores que ZERO!");

            if (qtdItems > 10)
                return BadRequest("O tamanho máximo de página é 10");

            int totalPaginas = (int)Math.Ceiling(db.Livros.Count() / Convert.ToDecimal(qtdItems));

            if (pagina > totalPaginas) return NotFound();

            HttpContext.Current.Response.AddHeader("X-Desenvolvedor", "Robson D. Oliveira");

            var livros = db.Livros.OrderBy(c => c.Codigo).Skip(qtdItems * (pagina - 1)).Take(qtdItems);
          
            return Ok(livros);
        }

        // GET ID - RETORNAR POR ID
        public IHttpActionResult GetLivroID(int Id)
        {
            if (Id < 1)
                return BadRequest("O código do livro deve ser maior que zero");

            var livro = db.Livros.Find(Id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        // PUT - ATUALIZAR
        [EnableQuery]
        public IHttpActionResult PutLivro(int Id, Livro livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Id != livro.Codigo)
                return BadRequest("O ID informado´na URL é diferente do código do livro!");

            if (db.Livros.Count(l => l.Codigo == livro.Codigo) == 0)
                return NotFound();

            db.Entry(livro).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE - DELETAR
        public IHttpActionResult DeleteLivro(int id)
        {
            if (id < 1) return BadRequest("O ID deve ser maior que ZERO!");

            Livro livro = db.Livros.Find(id);
            if (livro == null) return NotFound();

            db.Entry(livro).State = EntityState.Deleted;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

/* PRIMEIRA PARTE DA AULA
 public class LivrosController : ApiController
    {
        BancoContext db = new BancoContext();

        // POST - ENVIAR
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livros.Add(livro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = livro.Codigo }, livro);
        }

        // GET - RETORNAR
        public IHttpActionResult GetLivros()
        {
            var livros = db.Livros;
            return Ok(livros);
        }

        // GET ID - RETORNAR POR ID
        public IHttpActionResult GetLivroID(int Id)
        {
            if (Id < 1)
                return BadRequest("O código do livro deve ser maior que zero");

            var livro = db.Livros.Find(Id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        // PUT - ATUALIZAR
        public IHttpActionResult PutLivro(int Id, Livro livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Id != livro.Codigo)
                return BadRequest("O ID informado´na URL é diferente do código do livro!");

            if (db.Livros.Count(l => l.Codigo == livro.Codigo) == 0)
                return NotFound();

            db.Entry(livro).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE - DELETAR
        public IHttpActionResult DeleteLivro(int id)
        {
            if (id < 1) return BadRequest("O ID deve ser maior que ZERO!");

            Livro livro = db.Livros.Find(id);
            if (livro == null) return NotFound();

            db.Entry(livro).State = EntityState.Deleted;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        } 
    }
*/
