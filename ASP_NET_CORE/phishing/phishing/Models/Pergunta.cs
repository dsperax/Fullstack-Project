using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phishing.Models
{
    public class Pergunta
    {
        public int Id { get; set; }

        public int Num_Pergunta { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Resposta { get; set; }
    }
}
