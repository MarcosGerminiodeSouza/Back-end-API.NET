using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace livrariaAPI.Models.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string TipoCategoria { get; set; }
    }
}