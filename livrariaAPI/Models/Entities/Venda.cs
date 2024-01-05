using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace livrariaAPI.Models.Entities
{
    public class Venda
    {
        [Key()]
        public int VendaId { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now.ToLocalTime();
    }
}