using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.UsuarioService
{
    public interface IUsuarioInterface
    {
        Task<ServiceResponse<List<Usuario>>> CriarUsuario(Usuario novoUsuario);
        Task<ServiceResponse<List<Usuario>>> ObterUsuarios();
        Task<ServiceResponse<Usuario>> ObterUsuarioPorId(int id);
        Task<ServiceResponse<List<Usuario>>> EditarUsuario(Usuario editadoUsuario);
        Task<ServiceResponse<List<Usuario>>> DeletarUsuario(int id);
    }
}