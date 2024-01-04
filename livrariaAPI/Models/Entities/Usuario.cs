using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace livrariaAPI.Models.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
}