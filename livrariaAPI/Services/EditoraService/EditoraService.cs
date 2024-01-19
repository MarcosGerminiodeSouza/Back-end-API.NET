using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.EditoraService
{
    public class EditoraService : IEditoraInterface
    {
        private readonly LivrariaContext _context;
        
        public EditoraService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Editora>>> CriarEditora(Editora novaEditora)
        {
            ServiceResponse<List<Editora>> serviceResponse = new ServiceResponse<List<Editora>>();

            try
            {
                if (novaEditora == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaEditora);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Editoras.ToListAsync();
                serviceResponse.Menssagem = $"Nova editora adicionada a tabela de editoras com Id: {novaEditora.idt_editora}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<Editora>>> ObterEditoras()
        {
            ServiceResponse<List<Editora>> serviceResponse = new ServiceResponse<List<Editora>>();
            try
            {
                serviceResponse.Dados = await _context.Editoras.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Editora>> ObterEditoraPorId(int id)
        {
            ServiceResponse<Editora> serviceResponse = new ServiceResponse<Editora>();

            try
            {
                Editora editoraBanco = await _context.Editoras.FirstOrDefaultAsync(x => x.idt_editora == id);

                if (editoraBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma editora encontrada na tabela editoras com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = editoraBanco;
                    serviceResponse.Menssagem = "Editora encontrada!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Editora>>> EditarEditora(Editora editadaEditora)
        {
            ServiceResponse<List<Editora>> serviceResponse = new ServiceResponse<List<Editora>>();

            try
            {
                Editora editoraBanco = await _context.Editoras.AsNoTracking().FirstOrDefaultAsync(x => x.idt_editora == editadaEditora.idt_editora);

                if (editoraBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma editora encontrada na tabela categorias com Id: {editadaEditora.idt_editora}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Editoras.Update(editadaEditora);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Editoras.ToListAsync();
                    serviceResponse.Menssagem = $"Edita categoria com Id: {editoraBanco.idt_editora}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Editora>>> DeletarEditora(int id)
        {
           ServiceResponse<List<Editora>> serviceResponse = new ServiceResponse<List<Editora>>();

            try
            {
                Editora editora = await _context.Editoras.FirstOrDefaultAsync(x => x.idt_editora == id);

                if (editora == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhuma editora encontrada na tabela editoras com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Editoras.Remove(editora);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Editoras.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta editora com Id: {id}";
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