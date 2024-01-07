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
    public class MarcosLivrariaController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public MarcosLivrariaController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpPost("criarLivro/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> CriarLivro(Livro novoLivro)
        {
            return Ok(await _livroInterface.CriarLivro(novoLivro));
        }

        [HttpGet("obterLivros")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> ObterLivros()
        {
            return Ok(await _livroInterface.ObterLivros());
        }

        [HttpGet("obterLivroPorId/{id}")]
        public async Task<ActionResult<ServiceResponse<Livro>>> ObterLivroPorId(int id)
        {
            ServiceResponse<Livro> serviceResponse = await _livroInterface.ObterLivroPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPut("editarLivro/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> EditarLivro(Livro editadoLivro)
        {
           ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.EditarLivro(editadoLivro);

            return Ok(serviceResponse);
        }

        [HttpPut("adicionaLancamentoLivro/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> AdicionaLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.AdicionaLancamentoLivro(id);

            return Ok(serviceResponse);
        }

        [HttpPut("removeLancamentoLivro/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> RemoveLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.RemoveLancamentoLivro(id);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletarLivro/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> DeletarLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.DeletarLivro(id);

            return Ok(serviceResponse);
        }

    }
}