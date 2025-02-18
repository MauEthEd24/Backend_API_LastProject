using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class APIContext:DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ETHPHOS; Database=LastProject2025; Integrated Security=True; Trust Server Certificate=True");
        }
    }
}
