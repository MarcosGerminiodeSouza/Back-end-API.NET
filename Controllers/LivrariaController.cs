using System;
using System.Linq;
using System.Collections.Generic;
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

        public LivrariaController(LivrariaDbContext context)
        {
            _context = context;

            //rollback banco de dados (mocking)
            foreach (Livro x in _context.Livros)
                _context.Livros.Remove(x);
            _context.SaveChanges();

            _context.Livros.Add(new Livro { Id = 1, Nome = "SHERLOCK HOLMES", Autor = "Arthur Conan Doyle", Categoria = "Mistério", Preco = 89.94M, Quantidade = 5, Imagem = "img1" });
            _context.Livros.Add(new Livro { Id = 2, Nome = "O MUNDO DE SOFIA", Autor = "Jostein Gaarder", Categoria = "Românce", Preco = 19.94M, Quantidade = 6, Imagem = "img2" });
            _context.Livros.Add(new Livro { Id = 3, Nome = "ARCÈNE LUPIN O Ladrão de Casaca", Autor = "Maurice Leblanc", Categoria = "Ficção", Preco = 29.90M, Quantidade = 10, Imagem = "img3" });
            _context.Livros.Add(new Livro { Id = 4, Nome = "INTRODUÇÃO À PROGRAMAÇÃO", Autor = "Anita Lopes", Categoria = "Programação", Preco = 120.00M, Quantidade = 9, Imagem = "img4" });
            _context.Livros.Add(new Livro { Id = 5, Nome = "Guia Front-End", Autor = "Diego ES", Categoria = "Programação", Preco = 115.15M, Quantidade = 8, Imagem = "img5" });
            _context.Livros.Add(new Livro { Id = 6, Nome = "Aprenda a Programar com C#", Autor = "António Trigo", Categoria = "Programação", Preco = 99.99M, Quantidade = 10, Imagem = "img6" });
            _context.Livros.Add(new Livro { Id = 7, Nome = "Use a Cabeça! C#", Autor = "Andrew Stellman", Categoria = "Programação", Preco = 100.94M, Quantidade = 5, Imagem = "img7" });
            _context.Livros.Add(new Livro { Id = 8, Nome = "Introdução à linguagem SQL", Autor = "Tomas Nield", Categoria = "Banco de Dados", Preco = 149.90M, Quantidade = 10, Imagem = "img8" });
            _context.Livros.Add(new Livro { Id = 9, Nome = "MySQL Aprendendo na Prática", Autor = "Sérgio Luiz Tonsig", Categoria = "Banco de Dados", Preco = 188.80M, Quantidade = 7, Imagem = "img9" });
            _context.Livros.Add(new Livro { Id = 10, Nome = "O PODER DO HÁBITO", Autor = "Charles Duhigg", Categoria = "Autoajuda", Preco = 50.00M, Quantidade = 6, Imagem = "img10" });

            _context.SaveChanges();
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> CriarLivro(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterLivro), new {id = livro.Id}, livro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> ObterLivro(int id)
        {
            var livroBanco = await _context.Livros.FindAsync(id);

            if (livroBanco == null)
                return NotFound();

            return Ok(livroBanco);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterLivros()
        {
            var livroBanco = await _context.Livros.ToListAsync();

            return Ok(livroBanco);
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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