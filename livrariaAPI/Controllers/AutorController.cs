using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.AutorService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ServiceResponse<List<Autor>>>> CriarAutor(Autor novoAutor)
        {
            return Ok(await _autorInterface.CriarAutor(novoAutor));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Autor>>>> ObterAutores()
        {
            return Ok(await _autorInterface.ObterAutores());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Autor>>> ObterAutorPorId(int id)
        {
            ServiceResponse<Autor> serviceResponse = await _autorInterface.ObterAutorPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editar")]
        public async Task<ActionResult<ServiceResponse<List<Autor>>>> EditarAutor(Autor editadoAutor)
        {
           ServiceResponse<List<Autor>> serviceResponse = await _autorInterface.EditarAutor(editadoAutor);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Autor>>>> DeletarAutor(int id)
        {
            ServiceResponse<List<Autor>> serviceResponse = await _autorInterface.DeletarAutor(id);

            return Ok(serviceResponse);
        }
    }
}