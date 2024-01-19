using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.VendaService
{
    public interface IVendaInterface
    {
        Task<ServiceResponse<List<Venda>>> CriarVenda(Venda novaVenda);
        Task<ServiceResponse<List<Venda>>> ObterVendas();
        Task<ServiceResponse<Venda>> ObterVendaPorId(int id);
        Task<ServiceResponse<List<Venda>>> DeletarVenda(int id);
    }
}