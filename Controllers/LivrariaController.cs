using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaAPI.Models.Context;
using LivrariaAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrariaController : ControllerBase
    {
        private readonly LivrariaDbContext _context;

        //Injeção de dependencias.
        public LivrariaController(LivrariaDbContext context)
        {
            _context = context;
        }

        [HttpPost("Novo")]
        public async Task<ActionResult<Livro>> CriarLivro(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterLivro), new {id = livro.Id}, livro);
        }

        [HttpGet("Listar/{id}")]
        public async Task<ActionResult<Livro>> ObterLivro(int id)
        {
            var livroBanco = await _context.Livros.FindAsync(id);

            if (livroBanco == null)
                return NotFound();

            return Ok(livroBanco);
        }

        [HttpGet("Listar/")]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterLivros()
        {
            var livroBanco = await _context.Livros.ToListAsync();

            return Ok(livroBanco);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<Livro>> AtualizarLivro(int id, Livro livro)
        {
            var livroBanco = await _context.Livros.FindAsync(id);

            if (livroBanco == null)
                return NotFound();

            livroBanco.Nome = livro.Nome;
            livroBanco.Autor = livro.Autor;
            livroBanco.Categoria = livro.Categoria;
            livroBanco.Preco = livro.Preco;
            livroBanco.Quantidade = livro.Quantidade;
            livroBanco.Imagem = livro.Imagem;

            _context.Livros.Update(livroBanco);
            await _context.SaveChangesAsync();

            return Ok(livroBanco);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<Livro>> DeletarLivro(int id)
        {
            var livroBanco = await _context.Livros.FindAsync(id);

            if (livroBanco == null)
                return NotFound();

            _context.Livros.Remove(livroBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}