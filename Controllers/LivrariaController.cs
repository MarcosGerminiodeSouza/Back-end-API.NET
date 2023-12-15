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
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly LivrariaDbContext _contexto;

        public LivrariaController(LivrariaDbContext contexto)
        {
            _contexto = contexto;

            foreach (Livro x in _contexto.Livros)
                _contexto.Livros.Remove(x);
            _contexto.SaveChanges();

            _contexto.Livros.Add(new Livro { Id = 1, Nome = "CHERLOCK HOMES", Autor = "Arthur Conan Doyle", Categoria = "Mistério", Preco = 80, Quantidade = 5, Imagem = "img1" });
            _contexto.Livros.Add(new Livro { Id = 2, Nome = "O MUNDO DE SOFIA", Autor = "Jostein Gaarder", Categoria = "Românce", Preco = 20, Quantidade = 6, Imagem = "img2" });
            _contexto.Livros.Add(new Livro { Id = 3, Nome = "ARCÈNE LUPIN O Ladrão de Casaca", Autor = "Maurice Leblanc", Categoria = "Ficção", Preco = 30, Quantidade = 10, Imagem = "img3" });
            _contexto.Livros.Add(new Livro { Id = 4, Nome = "INTRODUÇÃO À PROGRAMAÇÃO", Autor = "Anita Lopes", Categoria = "Programação", Preco = 120, Quantidade = 9, Imagem = "img4" });
            _contexto.Livros.Add(new Livro { Id = 5, Nome = "Guia Front-End", Autor = "Diego ES", Categoria = "Programação", Preco = 110, Quantidade = 8, Imagem = "img5" });
            _contexto.Livros.Add(new Livro { Id = 6, Nome = "Aprenda a Programar com C#", Autor = "António Trigo", Categoria = "Programação", Preco = 130, Quantidade = 10, Imagem = "img6" });
            _contexto.Livros.Add(new Livro { Id = 7, Nome = "Use a Cabeça! C#", Autor = "Andrew Stellman", Categoria = "Programação", Preco = 100, Quantidade = 5, Imagem = "img7" });
            _contexto.Livros.Add(new Livro { Id = 8, Nome = "Introdução à linguagem SQL", Autor = "Tomas Nield", Categoria = "Banco de Dados", Preco = 180, Quantidade = 10, Imagem = "img8" });
            _contexto.Livros.Add(new Livro { Id = 9, Nome = "MySQL Aprendendo na Prática", Autor = "Sérgio Luiz Tonsig", Categoria = "Banco de Dados", Preco = 150, Quantidade = 7, Imagem = "img9" });
            _contexto.Livros.Add(new Livro { Id = 10, Nome = "O PODER DO HÁBITO", Autor = "Charles Duhigg", Categoria = "Autoajuda", Preco = 50, Quantidade = 6, Imagem = "img10" });

            _contexto.SaveChanges();
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            _contexto.Livros.Add(livro);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = livro.Id }, livro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterTudo()
        {
            return await _contexto.Livros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> ObterPorId(int id)
        {
            var item = await _contexto.Livros.FindAsync(id.ToString());

            if (item == null)
                return NotFound();

            return item;
        }
    }
}