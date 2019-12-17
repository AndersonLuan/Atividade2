using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade2.Models
{
    public class PecasRoupa
    {
        [Key]
        public int Id { get; set; }
        public  string TipoRoupa { get; set; }
        public int Quantidade { get; set; }
    }
}
