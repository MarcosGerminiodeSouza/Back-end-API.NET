using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.CategoriaService
{
    public interface ICategoriaInterface
    {
        Task<ServiceResponse<List<Categoria>>> CriarCategoria(Categoria novaCategoria);
        Task<ServiceResponse<List<Categoria>>> ObterCategorias();
        Task<ServiceResponse<Categoria>> ObterCategoriaPorId(int id);
        Task<ServiceResponse<List<Categoria>>> EditarCategoria(Categoria editadaCategoria);
        Task<ServiceResponse<List<Categoria>>> DeletarCategoria(int id);
    }
}