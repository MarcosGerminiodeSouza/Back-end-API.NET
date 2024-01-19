using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.VendaService
{
    public class VendaService : IVendaInterface
    {
        private readonly LivrariaContext _context;

        public VendaService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Venda>>> CriarVenda(Venda novaVenda)
        {
            ServiceResponse<List<Venda>> serviceResponse = new ServiceResponse<List<Venda>>();

            try
            {
                if (novaVenda == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaVenda);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Vendas.ToListAsync();
                serviceResponse.Menssagem = $"Novo registro adicionado a tabela de vendas com Id: {novaVenda.idt_venda}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Venda>>> ObterVendas()
        {
            ServiceResponse<List<Venda>> serviceResponse = new ServiceResponse<List<Venda>>();
            try
            {
                serviceResponse.Dados = await _context.Vendas.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Venda>> ObterVendaPorId(int id)
        {
            ServiceResponse<Venda> serviceResponse = new ServiceResponse<Venda>();

            try
            {
                Venda vendaBanco = await _context.Vendas.FirstOrDefaultAsync(x => x.idt_venda == id);

                if (vendaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum registro encontrado na tabela vendas com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = vendaBanco;
                    serviceResponse.Menssagem = "Registro encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Venda>>> DeletarVenda(int id)
        {
            ServiceResponse<List<Venda>> serviceResponse = new ServiceResponse<List<Venda>>();

            try
            {
                Venda vendaBanco = await _context.Vendas.FirstOrDefaultAsync(x => x.idt_venda == id);

                if (vendaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum registro encontrado na tabela vendas com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Vendas.Remove(vendaBanco);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Vendas.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta registro com Id: {id}";
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