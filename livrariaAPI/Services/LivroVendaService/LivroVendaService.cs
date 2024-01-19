using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.LivroVendaService
{
    public class LivroVendaService : ILivroVendaInterface
    {
        private readonly LivrariaContext _context;

        public LivroVendaService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<LivroVenda>>> CriarLivroVenda(LivroVenda novoLivroVenda)
        {
            ServiceResponse<List<LivroVenda>> serviceResponse = new ServiceResponse<List<LivroVenda>>();

            try
            {
                if (novoLivroVenda == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoLivroVenda);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.livro_venda.ToListAsync();
                serviceResponse.Menssagem = $"Novo registro adicionado a tabela de livro-vendas com Id: {novoLivroVenda.idt_livro_venda}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<LivroVenda>>> ObterLivroVendas()
        {
            ServiceResponse<List<LivroVenda>> serviceResponse = new ServiceResponse<List<LivroVenda>>();
            try
            {
                serviceResponse.Dados = await _context.livro_venda.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<LivroVenda>> ObterLivroVendaPorId(int id)
        {
            ServiceResponse<LivroVenda> serviceResponse = new ServiceResponse<LivroVenda>();

            try
            {
                LivroVenda livroVendaBanco = await _context.livro_venda.FirstOrDefaultAsync(x => x.idt_livro_venda == id);

                if (livroVendaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum registro encontrado na tabela livro-vendas com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = livroVendaBanco;
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

        public async Task<ServiceResponse<List<LivroVenda>>> DeletarLivroVenda(int id)
        {
            ServiceResponse<List<LivroVenda>> serviceResponse = new ServiceResponse<List<LivroVenda>>();

            try
            {
                LivroVenda livroVendaBanco = await _context.livro_venda.FirstOrDefaultAsync(x => x.idt_livro_venda == id);

                if (livroVendaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum registro encontrado na tabela livro-vendas com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.livro_venda.Remove(livroVendaBanco);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.livro_venda.ToListAsync();
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