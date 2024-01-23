using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<ServiceResponse<List<Livro>>> InserirNovoLivro(Livro novoLivro);
        Task<ServiceResponse<List<Livro>>> ObterLivros();
        Task<ServiceResponse<List<Livro>>> ObterLancamentos();
        Task<ServiceResponse<Livro>> ObterLivroPorId(int id);
        Task<ServiceResponse<List<Livro>>> EditarLivro(Livro editadoLivro);
        Task<ServiceResponse<List<Livro>>> DeletarLivro(int id);
    }
}