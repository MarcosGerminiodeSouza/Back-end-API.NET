using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int idt_usuario { get; set; }

        [Column(TypeName ="char(10)")]
        public string log_usuario { get; set; }

        [Column(TypeName ="char(4)")]
        public string des_senha { get; set; }
    }
}