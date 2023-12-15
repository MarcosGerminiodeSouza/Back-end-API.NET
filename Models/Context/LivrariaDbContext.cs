using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI.Models.Context
{
    public class LivrariaDbContext : DbContext
    {
        public LivrariaDbContext(DbContextOptions<LivrariaDbContext> option) : base(option)
        {
            
        }

        public DbSet<Livro> Livros { get; set; }
        
    }
}