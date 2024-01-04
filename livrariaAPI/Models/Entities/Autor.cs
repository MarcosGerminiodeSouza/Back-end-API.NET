using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace livrariaAPI.Models.Entities
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string NomeAutor { get; set; }
    }
}