using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace livrariaAPI.Models.Entities
{
    public class Editora
    {
        public int EditoraId { get; set; }
        public string NomeEditora { get; set; }
    }
}