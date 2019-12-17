using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atividade2.Models;

namespace Atividade2.Data
{
    public class Atividade2Context : DbContext
    {
        public Atividade2Context (DbContextOptions<Atividade2Context> options)
            : base(options)
        {
        }

        public DbSet<Atividade2.Models.PecasRoupa> PecasRoupa { get; set; }

        public DbSet<Atividade2.Models.Confeccoes> Confeccoes { get; set; }
    }
}
