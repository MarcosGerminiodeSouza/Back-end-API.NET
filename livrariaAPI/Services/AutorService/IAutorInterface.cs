using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.AutorService
{
    public interface IAutorInterface
    {
        Task<ServiceResponse<List<Autor>>> CriarAutor(Autor novoAutor);
        Task<ServiceResponse<List<Autor>>> ObterAutores();
        Task<ServiceResponse<Autor>> ObterAutorPorId(int id);
        Task<ServiceResponse<List<Autor>>> EditarAutor(Autor editadoAutor);
        Task<ServiceResponse<List<Autor>>> DeletarAutor(int id);
    }
}