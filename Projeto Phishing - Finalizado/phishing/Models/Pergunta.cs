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

        public string ConteudoDiv { get; set; }

        public string MensagemAcerto { get; set; }

        public string MensagemErro { get; set; }

        public string DescricaoResposta { get; set; }

        public string BotaoProximaPergunta { get; set; }

        public string BotaoRespostas { get; set; }
    }
}
