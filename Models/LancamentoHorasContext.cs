using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LubySoftware.Models
{
    public class LancamentoHorasContext : DbContext
    {
        public LancamentoHorasContext(DbContextOptions<LancamentoHorasContext> options)
            : base(options)
        {
        }

        public DbSet<LancamentoHoras> LubySoftware { get; set; }
    }
}
