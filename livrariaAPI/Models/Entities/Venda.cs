using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace livrariaAPI.Models.Entities
{
    public class Venda
    {
        [Key]
        public int idt_venda { get; set; }

        [ForeignKey("Usuario")]
        public int idt_usuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Column(TypeName ="date")]
        public DateOnly dat_venda { get; set; }
    }
}