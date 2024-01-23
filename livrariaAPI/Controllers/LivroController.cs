using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using livrariaAPI.Services.LivroService;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> InserirNovoLivro(Livro novoLivro)
        {
            return Ok(await _livroInterface.InserirNovoLivro(novoLivro));
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> ObterLivros()
        {
            return Ok(await _livroInterface.ObterLivros());
        }

        [HttpGet("obter/lancamento")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> ObterLancamentos()
        {
            return Ok(await _livroInterface.ObterLancamentos());
        }

        [HttpGet("obter/{id}")]
        public async Task<ActionResult<ServiceResponse<Livro>>> ObterLivroPorId(int id)
        {
            ServiceResponse<Livro> serviceResponse = await _livroInterface.ObterLivroPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editar")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> EditarLivro(Livro editadoLivro)
        {
           ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.EditarLivro(editadoLivro);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> DeletarLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.DeletarLivro(id);

            return Ok(serviceResponse);
        }
    }
}