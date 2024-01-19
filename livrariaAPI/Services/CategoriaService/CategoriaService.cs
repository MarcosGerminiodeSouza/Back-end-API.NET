using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.CategoriaService
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly LivrariaContext _context;
        
        public CategoriaService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Categoria>>> CriarCategoria(Categoria novaCategoria)
        {
            ServiceResponse<List<Categoria>> serviceResponse = new ServiceResponse<List<Categoria>>();

            try
            {
                if (novaCategoria == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaCategoria);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Categorias.ToListAsync();
                serviceResponse.Menssagem = $"Nova categoria adicionada a tabela de categorias com Id: {novaCategoria.idt_categoria}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<Categoria>>> ObterCategorias()
        {
            ServiceResponse<List<Categoria>> serviceResponse = new ServiceResponse<List<Categoria>>();
            try
            {
                serviceResponse.Dados = await _context.Categorias.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Categoria>> ObterCategoriaPorId(int id)
        {
            ServiceResponse<Categoria> serviceResponse = new ServiceResponse<Categoria>();

            try
            {
                Categoria categoriaBanco = await _context.Categorias.FirstOrDefaultAsync(x => x.idt_categoria == id);

                if (categoriaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma categoria encontrada na tabela categorias com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = categoriaBanco;
                    serviceResponse.Menssagem = "Categoria encontrada!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Categoria>>> EditarCategoria(Categoria editadaCategoria)
        {
            ServiceResponse<List<Categoria>> serviceResponse = new ServiceResponse<List<Categoria>>();

            try
            {
                Categoria categoriaBanco = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.idt_categoria == editadaCategoria.idt_categoria);

                if (categoriaBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma categoria encontrada na tabela categorias com Id: {editadaCategoria.idt_categoria}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Categorias.Update(editadaCategoria);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Categorias.ToListAsync();
                    serviceResponse.Menssagem = $"Edita categoria com Id: {categoriaBanco.idt_categoria}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Categoria>>> DeletarCategoria(int id)
        {
           ServiceResponse<List<Categoria>> serviceResponse = new ServiceResponse<List<Categoria>>();

            try
            {
                Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.idt_categoria == id);

                if (categoria == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma categoria encontrada na tabela categorias com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Categorias.Remove(categoria);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Categorias.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta categoria com Id: {id}";
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