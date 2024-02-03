using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.EditoraService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraInterface _editoraInterface;

        public EditoraController(IEditoraInterface editoraInterface)
        {
            _editoraInterface = editoraInterface;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ServiceResponse<List<Editora>>>> CriarEditora(Editora novaEditora)
        {
            return Ok(await _editoraInterface.CriarEditora(novaEditora));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Editora>>>> ObterEditoras()
        {
            return Ok(await _editoraInterface.ObterEditoras());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Editora>>> ObterEditoraPorId(int id)
        {
            ServiceResponse<Editora> serviceResponse = await _editoraInterface.ObterEditoraPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editar")]
        public async Task<ActionResult<ServiceResponse<List<Editora>>>> EditarEditora(Editora editadoEditora)
        {
           ServiceResponse<List<Editora>> serviceResponse = await _editoraInterface.EditarEditora(editadoEditora);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Editora>>>> DeletarEditora(int id)
        {
            ServiceResponse<List<Editora>> serviceResponse = await _editoraInterface.DeletarEditora(id);

            return Ok(serviceResponse);
        }
    }
}