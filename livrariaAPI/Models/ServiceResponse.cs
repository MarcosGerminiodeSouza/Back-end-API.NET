using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livrariaAPI.Models
{
    public class ServiceResponse<T>
    {
        public T Dados { get; set; }
        public string Menssagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}