using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.LivroVendaService
{
    public interface ILivroVendaInterface
    {
        Task<ServiceResponse<List<LivroVenda>>> CriarLivroVenda(LivroVenda novoLivroVenda);
        Task<ServiceResponse<List<LivroVenda>>> ObterLivroVendas();
        Task<ServiceResponse<LivroVenda>> ObterLivroVendaPorId(int id);
        Task<ServiceResponse<List<LivroVenda>>> DeletarLivroVenda(int id);
    }
}