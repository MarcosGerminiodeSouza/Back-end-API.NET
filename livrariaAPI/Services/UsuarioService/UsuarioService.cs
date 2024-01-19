using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.UsuarioService
{
    public class UsuarioService : IUsuarioInterface
    {
        
        private readonly LivrariaContext _context;

        public UsuarioService(LivrariaContext context)
        {
            _context = context;
        }
        
        public async Task<ServiceResponse<List<Usuario>>> CriarUsuario(Usuario novoUsuario)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                if (novoUsuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Usuarios.ToListAsync();
                serviceResponse.Menssagem = $"Novo usuario adicionado a tabela de usuarios com Id: {novoUsuario.idt_usuario}";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Usuario>>> ObterUsuarios()
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();
            try
            {
                serviceResponse.Dados = await _context.Usuarios.ToListAsync();
                serviceResponse.Menssagem = $"Registros encontrados: ({serviceResponse.Dados.Count})";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Usuario>> ObterUsuarioPorId(int id)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();

            try
            {
                Usuario usuarioBanco = await _context.Usuarios.FirstOrDefaultAsync(x => x.idt_usuario == id);

                if (usuarioBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum usuario encontrado na tabela usuarios com Id: {id}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = usuarioBanco;
                    serviceResponse.Menssagem = "Usuario encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Usuario>>> EditarUsuario(Usuario editadoUsuario)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                Usuario usuarioBanco = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.idt_usuario == editadoUsuario.idt_usuario);

                if (usuarioBanco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum usuario encontrado na tabela usuarios com Id: {editadoUsuario.idt_usuario}";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Usuarios.Update(editadoUsuario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Usuarios.ToListAsync();
                    serviceResponse.Menssagem = $"Edita usuario com Id: {usuarioBanco.idt_usuario}";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }        

        public async Task<ServiceResponse<List<Usuario>>> DeletarUsuario(int id)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.idt_usuario == id);

                if (usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = $"Nenhum usuario encontrado na tabela usuarios com Id: {id}";
                    serviceResponse.Sucesso = false;                    
                }
                else
                {
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Usuarios.ToListAsync();
                    serviceResponse.Menssagem = $"Deleta usuario com Id: {id}";
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