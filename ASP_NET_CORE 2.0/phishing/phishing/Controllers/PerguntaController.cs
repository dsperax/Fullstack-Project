using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phishing.Models;
using phishing.Models.ViewModels;
using phishing.Services;

namespace phishing.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly PerguntaService _perguntaService;

        public int acertos = 0;
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

        public Pergunta GetPerguntaByNumber(int numeroPergunta)
        {
            //metodo de salvar resultado numa lista
            List<Pergunta> perguntas = new List<Pergunta>();

            perguntas.Add(new Pergunta
            {
                Titulo = "Vamos começar com este e - mail do Documentos Google.",
                Descricao = @"Confira os URLs dos links. Basta passar o cursor do mouse sobre eles ou tocar neles e os manter pressionados. Além disso, não deixe de verificar os endereços de e-mail. Não se preocupe, nenhum dos links funciona. Não queremos que você acesse nenhum site ""peculiar"".",
                Num_Pergunta = 1,
                Resposta = "PHISHING",
                ConteudoDiv = "<a href='drive--google.com' onclick='return false'><img src='~/static/q1.png' /></a>",
                DescricaoResposta = "<div>Você deve ter percebido o URL parecido. Cuidado ao abrir hiperlinks e anexos dentro de e-mails, porque eles podem direcionar você para sites fraudulentos que pedem informações confidenciais.</div>",
                MensagemAcerto = "Correto! Este é um e-mail de phishing.",
                MensagemErro = "Errado, na verdade esse e-mail é um phishing.",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Você recebeu um fax.",
                Descricao = @"Sabemos que você não perde tempo, mas vá no seu ritmo.",
                Num_Pergunta = 2,
                Resposta = "PHISHING",
                ConteudoDiv = "<img src='~/static/q2.png'/>",
                DescricaoResposta =" <div> O domínio do e - mail do remetente tem um erro ortográfico “efacks”. O nome correto seria “efax”.</div>",
                MensagemAcerto = "Correto! Este é um e-mail de phishing.",
                MensagemErro = "Errado!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Vamos relembrar os bons tempos!",
                Descricao = @"Você se lembra de algum colega da escola chamado TK?",
                Num_Pergunta = 3,
                Resposta = "PHISHING",
                ConteudoDiv = "<img src='~/static/q3.png'/><p style='display: flex; margin-left: 1rem;'>oi, você se lembra<a href='www.sytez.net' style='text-decoration: none;'>DESTA FOTO</a>?</p>",
                DescricaoResposta = "<div>Na verdade, o domínio é “sytez.net”, mas o site imita a aparência do Google Drive. Tenha ainda mais cuidado se você não conhecer o remetente.</div>",
                MensagemAcerto = "Correto! Este é um e-mail de phishing.",
                MensagemErro = "Errado! Confira o URL, pois mesmo sendo parecido não está correto.",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Essa, não! Parece que você está sem espaço de armazenamento.",
                Descricao = @"Essa, não! Parece que você está sem espaço de armazenamento.",
                Num_Pergunta = 4,
                Resposta = "VERDADEIRO",
                ConteudoDiv = "<a href='https://wwww.dropbox.com.br' onclick='return false' ><img src='~/static/q4.png'/></a>",
                DescricaoResposta = "<div>O remetente é “dropboxmail.com”, que é um endereço verdadeiro, embora incomum. E o URL é um link seguro (https) que aponta para “dropbox.com”.</div>",
                MensagemAcerto = "Correto!",
                MensagemErro = "Opa, esse é um email VERDADEIRO!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Você recebeu um novo tipo de relatório da escola.",
                Descricao = @"Normalmente, os e-mails dela vêm do endereço “sandra.maia@escolanota10.org”.",
                Num_Pergunta = 5,
                Resposta = "PHISHING",
                ConteudoDiv = "<img src='~/static/q5.png'/>",
                DescricaoResposta = "<div>Este foi um ataque de phishing difícil de perceber. PDFs podem conter malware ou vírus, por isso, verifique se o remetente é confiável e use o navegador ou um serviço on-line como o Google Drive para abri-los com segurança.</div>",
                MensagemAcerto = "Correto! Este é um e-mail de phishing.",
                MensagemErro = "Errado!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Alguém está tentando acessar sua conta.",
                Descricao = @"Observe com atenção antes de trocar sua senha.",
                Num_Pergunta = 6,
                Resposta = "PHISHING",
                ConteudoDiv = "<img src='~/static/q6.png' />",
                DescricaoResposta = "<div>Este é quase idêntico a um ataque que hackeou e-mails de políticos. Sempre confira os URLs com atenção.</div>",
                MensagemAcerto = "Correto! Este é um e-mail de phishing.",
                MensagemErro = "Errado! @google.support não é confiável!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Parece que sua conta está sendo atacada novamente.",
                Descricao = @"Ou será que não?",
                Num_Pergunta = 7,
                Resposta = "PHISHING",
                ConteudoDiv = "<img src='~/static/q7.1.png' /><div style='background-color: #f4f4f4;'><img src='~/static/q7.2.png'/><a href='www.sytez.net'><img src='~/static/q7.3.png' /></a></div>",
                DescricaoResposta = "<div>Os hackers tentaram usar o Google para esconder o link real, que é do TinyURL. Um e-mail parecido com esse foi usado para atacar think tanks e políticos.</div>",
                MensagemAcerto = "Correto. O e-mail se baseia em um alerta verdadeiro, mas leva o usuário para uma página de login falsa.",
                MensagemErro = "Errado! O e-mail é um alerta verdadeiro que leva a uma página falsa!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });
            perguntas.Add(new Pergunta
            {
                Titulo = "Você assinou um serviço de planejamento de viagens.",
                Descricao = @"Você quer que seu e-mail seja verificado, mas olhe com mais atenção.",
                Num_Pergunta = 8,
                Resposta = "VERDADEIRO",
                ConteudoDiv = "<img src='~/static/q8.1.png' /><a href='www.tripit.com'><img src='~/static/q8.2.png' /></a><img src='~/static/q8.3.png' />",
                DescricaoResposta = "<div>É importante ter cuidado com esses tipos de solicitações de acesso à conta e ter certeza de que o desenvolvedor é confiável. Confira o domínio mostrado e clique nele para saber mais detalhes.</div>",
                MensagemAcerto = "Correto! Este e-mail é verdadeiro.",
                MensagemErro = "Errado, esse é de verdade!",
                BotaoRespostas = "<button class='botao-alternativa' onclick='clicou()'>PHISHING</button><button class='botao-alternativa' onclick='clicou()'>VERDADEIRO</button>",
                BotaoProximaPergunta = "<button class='botao-alternativa' onclick='avancaProximaPergunta()'>PRÓXIMA PERGUNTA</button>"
            });

            return (from p in perguntas
                    where p.Num_Pergunta == numeroPergunta
                    select p).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult SalvaResposta([FromBody] Resposta resposta)
        {
            Pergunta pergunta = GetPerguntaByNumber(resposta.NumPergunta);

            if (resposta.RespostaPergunta == pergunta.Resposta)
            {
                acertos += 1;
            }

            ViewData["acertos"] = acertos;

            return Json("Sucesso");
        }

        [HttpGet]
        public Pergunta GetNextQuestion(int numPergunta)
        {
            Pergunta proxPergunta = GetPerguntaByNumber(numPergunta + 1);
            return proxPergunta;
        }

        [HttpGet]
        public Pergunta RespostaPergunta(int numPergunta)
        {
            Pergunta respPergunta = GetPerguntaByNumber(numPergunta + 1);
            return respPergunta;
        }
    }
}