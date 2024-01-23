using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly LivrariaContext _context;

        public LivroService(LivrariaContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Livro>>> InserirNovoLivro(Livro novoLivro)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                if (novoLivro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoLivro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Livros.ToListAsync();
                serviceResponse.Menssagem = $"Novo livro adicionado a tabela de livros com Id: {novoLivro.idt_livro}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> ObterLivros()
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();
            try
            {
                serviceResponse.Dados = await _context.Livros.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> ObterLancamentos()
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();
            try
            {
                serviceResponse.Dados = await _context.Livros
                    .Where(l => l.ind_lancamento == "s")
                    .ToListAsync();

                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Livro>> ObterLivroPorId(int id)
        {
            ServiceResponse<Livro> serviceResponse = new ServiceResponse<Livro>();

            try
            {
                Livro livroBanco = await _context.Livros.FirstOrDefaultAsync(x => x.idt_livro == id);

                if (livroBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum livro encontrado na tabela livros com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = livroBanco;
                    serviceResponse.Menssagem = "Livro encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> EditarLivro(Livro editadoLivro)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livroBanco = await _context.Livros.AsNoTracking().FirstOrDefaultAsync(x => x.idt_livro == editadoLivro.idt_livro);

                if (livroBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum livro encontrado na tabela livros com Id: {editadoLivro.idt_livro}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Livros.Update(editadoLivro);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Livros.ToListAsync();
                    serviceResponse.Menssagem = $"Edita livro com Id: {livroBanco.idt_livro}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> DeletarLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livroBanco = await _context.Livros.FirstOrDefaultAsync(x => x.idt_livro == id);

                if (livroBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum livro encontrado na tabela livros com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Livros.Remove(livroBanco);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Livros.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta livro com Id: {id}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}