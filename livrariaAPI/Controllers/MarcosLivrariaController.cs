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

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> ObterLivros()
        {
            return Ok(await _livroInterface.ObterLivros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Livro>>> ObterLivroPorId(int id)
        {
            ServiceResponse<Livro> serviceResponse = await _livroInterface.ObterLivroPorId(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> CriarLivro(Livro novoLivro)
        {
            return Ok(await _livroInterface.CriarLivro(novoLivro));
        }

        [HttpPut("inativaLancamento")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> InativaLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.InativaLancamentoLivro(id);

            return Ok(serviceResponse);
        }

        [HttpPut("ativaLancamento")]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> AtivaLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.AtivaLancamentoLivro(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> EditarLivro(Livro editadoLivro)
        {
           ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.EditarLivro(editadoLivro);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Livro>>>> DeletarLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = await _livroInterface.DeletarLivro(id);

            return Ok(serviceResponse);
        }

    }
}