using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.CategoriaService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaInterface _categoriaInterface;

        public CategoriaController(ICategoriaInterface categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> CriarCategoria(Categoria novaCategoria)
        {
            return Ok(await _categoriaInterface.CriarCategoria(novaCategoria));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> ObterCategorias()
        {
            return Ok(await _categoriaInterface.ObterCategorias());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Categoria>>> ObterCategoriaPorId(int id)
        {
            ServiceResponse<Categoria> serviceResponse = await _categoriaInterface.ObterCategoriaPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editar")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> EditarCategoria(Categoria editadoCategoria)
        {
           ServiceResponse<List<Categoria>> serviceResponse = await _categoriaInterface.EditarCategoria(editadoCategoria);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> DeletarCategoria(int id)
        {
            ServiceResponse<List<Categoria>> serviceResponse = await _categoriaInterface.DeletarCategoria(id);

            return Ok(serviceResponse);
        }
    }
}