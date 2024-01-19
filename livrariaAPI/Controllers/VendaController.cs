using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.VendaService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaInterface _vendaInterface;
        public VendaController(IVendaInterface vendaInterface)
        {
            _vendaInterface = vendaInterface;
        }

        [HttpPost("criar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Venda>>>> CriarVenda(Venda novaVenda)
        {
            return Ok(await _vendaInterface.CriarVenda(novaVenda));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Venda>>>> ObterVendas()
        {
            return Ok(await _vendaInterface.ObterVendas());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Venda>>> ObterVendaPorId(int id)
        {
            ServiceResponse<Venda> serviceResponse = await _vendaInterface.ObterVendaPorId(id);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Venda>>>> DeletarVenda(int id)
        {
            ServiceResponse<List<Venda>> serviceResponse = await _vendaInterface.DeletarVenda(id);

            return Ok(serviceResponse);
        }
    }
}