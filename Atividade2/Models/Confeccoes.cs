using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade2.Models
{
    public class Confeccoes
    {
        [Key]
        public int Id { get; set; }
        public PecasRoupa Reposicao { get; set; }
        public DateTime Registro { get; set; }
    }
}
