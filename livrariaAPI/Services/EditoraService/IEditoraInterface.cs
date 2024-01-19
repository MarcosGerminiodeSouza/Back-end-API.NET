using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;

namespace livrariaAPI.Services.EditoraService
{
    public interface IEditoraInterface
    {
        Task<ServiceResponse<List<Editora>>> CriarEditora(Editora novaEditora);
        Task<ServiceResponse<List<Editora>>> ObterEditoras();
        Task<ServiceResponse<Editora>> ObterEditoraPorId(int id);
        Task<ServiceResponse<List<Editora>>> EditarEditora(Editora editadaEditora);
        Task<ServiceResponse<List<Editora>>> DeletarEditora(int id);
    }
}