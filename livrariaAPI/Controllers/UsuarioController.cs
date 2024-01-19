using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("criar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> CriarUsuario(Usuario novoUsuario)
        {
            return Ok(await _usuarioInterface.CriarUsuario(novoUsuario));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> ObterUsuarios()
        {
            return Ok(await _usuarioInterface.ObterUsuarios());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> ObterUsuarioPorId(int id)
        {
            ServiceResponse<Usuario> serviceResponse = await _usuarioInterface.ObterUsuarioPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> EditarUsuario(Usuario editadoUsuario)
        {
           ServiceResponse<List<Usuario>> serviceResponse = await _usuarioInterface.EditarUsuario(editadoUsuario);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> DeletarUsuario(int id)
        {
            ServiceResponse<List<Usuario>> serviceResponse = await _usuarioInterface.DeletarUsuario(id);

            return Ok(serviceResponse);
        }
    }    
}