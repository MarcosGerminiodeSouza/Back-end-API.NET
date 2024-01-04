using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livrariaAPI.Models.Entities
{
    public class Venda
    {
        public int VendaId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
    }
}