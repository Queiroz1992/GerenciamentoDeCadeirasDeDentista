using GerenDeCadeiraDeDentista.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Infrastructure.Data
{
    public class CadeiraDentistaContext : DbContext
    {
        public CadeiraDentistaContext(DbContextOptions<CadeiraDentistaContext> options, IConfiguration configuration) : base(options)
        {
        }

        public DbSet<CadeiraDentista> CadeiraDentistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
