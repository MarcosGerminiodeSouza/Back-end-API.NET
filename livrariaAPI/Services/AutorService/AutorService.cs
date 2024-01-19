using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.AutorService
{
    public class AutorService : IAutorInterface
    {
        private readonly LivrariaContext _context;
        
        public AutorService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Autor>>> CriarAutor(Autor novoAutor)
        {
            ServiceResponse<List<Autor>> serviceResponse = new ServiceResponse<List<Autor>>();

            try
            {
                if (novoAutor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoAutor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Autores.ToListAsync();
                serviceResponse.Menssagem = $"Novo autor adicionado a tabela de autores com Id: {novoAutor.idt_autor}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<Autor>>> ObterAutores()
        {
            ServiceResponse<List<Autor>> serviceResponse = new ServiceResponse<List<Autor>>();
            try
            {
                serviceResponse.Dados = await _context.Autores.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Autor>> ObterAutorPorId(int id)
        {
            ServiceResponse<Autor> serviceResponse = new ServiceResponse<Autor>();

            try
            {
                Autor autorBanco = await _context.Autores.FirstOrDefaultAsync(x => x.idt_autor == id);

                if (autorBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum autor encontrado na tabela autores com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = autorBanco;
                    serviceResponse.Menssagem = "Autor encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Autor>>> EditarAutor(Autor editadoAutor)
        {
            ServiceResponse<List<Autor>> serviceResponse = new ServiceResponse<List<Autor>>();

            try
            {
                Autor autorBanco = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(x => x.idt_autor == editadoAutor.idt_autor);

                if (autorBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum autor encontrado na tabela autores com Id: {editadoAutor.idt_autor}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Autores.Update(editadoAutor);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Autores.ToListAsync();
                    serviceResponse.Menssagem = $"Edita autor com Id: {autorBanco.idt_autor}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Autor>>> DeletarAutor(int id)
        {
           ServiceResponse<List<Autor>> serviceResponse = new ServiceResponse<List<Autor>>();

            try
            {
                Autor autor = await _context.Autores.FirstOrDefaultAsync(x => x.idt_autor == id);

                if (autor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum autor encontrado na tabela autores com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Autores.Remove(autor);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Autores.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta autor com Id: {id}";
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