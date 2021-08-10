using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phishing.Models;
using phishing.Services;

namespace phishing.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly PerguntaService _perguntaService;
        public PerguntaController(PerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }

        public IActionResult Pergunta()
        {
            Pergunta pergunta = new Pergunta()
            {
                Titulo = "Vamos começar com este e - mail do Documentos Google.",
                Descricao = @"Confira os URLs dos links. Basta passar o cursor do mouse sobre eles ou tocar neles e os manter pressionados. Além disso, não deixe de verificar os endereços de e-mail. Não se preocupe, nenhum dos links funciona. Não queremos que você acesse nenhum site ""peculiar"".",
                Num_Pergunta = 1,
                Resposta = "PHISHING"
            };
            return View(pergunta);
        }

        [HttpGet]
        public List<Pergunta> GetPerguntaByNumber()
        {
            //metodo de salvar resultado numa lista
            List<Pergunta> perguntas = new List<Pergunta>();

            perguntas.Add(new Pergunta
                {
                    Titulo = "Você recebeu um fax.",
                    Descricao = @"Sabemos que você não perde tempo, mas vá no seu ritmo.",
                    Num_Pergunta = 2,
                    Resposta = "PHISHING"
                });
            perguntas.Add(new Pergunta
            {
                Titulo = "Vamos relembrar os bons tempos!",
                Descricao = @"Você se lembra de algum colega da escola chamado TK?",
                Num_Pergunta = 3,
                Resposta = "PHISHING"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Essa, não! Parece que você está sem espaço de armazenamento.",
                Descricao = @"Essa, não! Parece que você está sem espaço de armazenamento.",
                Num_Pergunta = 4,
                Resposta = "VERDADEIRO"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Você recebeu um novo tipo de relatório da escola.",
                Descricao = @"Normalmente, os e-mails dela vêm do endereço “sandra.maia@escolanota10.org”.",
                Num_Pergunta = 5,
                Resposta = "PHISHING"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Alguém está tentando acessar sua conta.",
                Descricao = @"Observe com atenção antes de trocar sua senha.",
                Num_Pergunta = 6,
                Resposta = "PHISHING"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Parece que sua conta está sendo atacada novamente.",
                Descricao = @"Ou será que não?",
                Num_Pergunta = 7,
                Resposta = "PHISHING"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Você assinou um serviço de planejamento de viagens.",
                Descricao = @"Você quer que seu e-mail seja verificado, mas olhe com mais atenção.",
                Num_Pergunta = 8,
                Resposta = "VERDADEIRO"
            });

            return perguntas;
        }

        //[HttpPost]
        //public IActionResult SalvaResposta(int num_Pergunta, string resposta)
        //{
        //    List<Pergunta> listaPerguntas = GetPerguntaByNumber();
        //    for(int i = 0; i < listaPerguntas.Count; i++)
        //    {
        //        return View();
        //    }
        //}
    }
}