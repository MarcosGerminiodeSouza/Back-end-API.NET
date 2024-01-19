using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.LivroVendaService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroVendaController : ControllerBase
    {
        private readonly ILivroVendaInterface _livroVendaInterface;
        public LivroVendaController(ILivroVendaInterface livroVendaInterface)
        {
            _livroVendaInterface = livroVendaInterface;
        }
        
        [HttpPost("criar")]
        public async Task<ActionResult<ServiceResponse<List<LivroVenda>>>> CriarLivroVenda(LivroVenda novoLivroVenda)
        {
            return Ok(await _livroVendaInterface.CriarLivroVenda(novoLivroVenda));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<LivroVenda>>>> ObterLivroVendas()
        {
            return Ok(await _livroVendaInterface.ObterLivroVendas());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<LivroVenda>>> ObterLivroVendaPorId(int id)
        {
            ServiceResponse<LivroVenda> serviceResponse = await _livroVendaInterface.ObterLivroVendaPorId(id);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<LivroVenda>>>> DeletarLivroVenda(int id)
        {
            ServiceResponse<List<LivroVenda>> serviceResponse = await _livroVendaInterface.DeletarLivroVenda(id);

            return Ok(serviceResponse);
        }
    }
}