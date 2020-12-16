using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubySoftware.Models
{
    public class LancamentoHoras
    {
        public long Id { get; set; }
        public string Data_inicio { get; set; }
        public string Data_fim { get; set; }
        public string Desenvolvedor { get; set; }
    }
}
