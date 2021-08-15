using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phishing.Data;
using phishing.Models;
using phishing.Models.ViewModels;

namespace phishing.Controllers
{
    public class PerguntaController : Controller
    {
        public int acertos = 0;

        public IActionResult Pergunta()
        {
            Pergunta pergunta = GetPerguntaByNumber(1);
            if (TempData.Count == 0) return RedirectToAction("Index", "Home");
            else return View(pergunta);
        }

        public Pergunta GetPerguntaByNumber(int numeroPergunta)
        {
            Bd_Conexao bd_Conexao = new Bd_Conexao();
            return bd_Conexao.getPerguntaByNumber(numeroPergunta);
        }

        [HttpPost]
        public IActionResult SalvaResposta([FromBody] Resposta resposta)
        {
            bool acertou = false;
            Pergunta pergunta = GetPerguntaByNumber(resposta.NumPergunta);

            if (resposta.RespostaPergunta == pergunta.Resposta)
            {
                acertou = true;
                TempData["pontuacao"] = Convert.ToInt32(TempData["pontuacao"]) + 1;
            }

            return Json(new { acertou = acertou});
        }

        [HttpGet]        
        public IActionResult GetNextQuestion(int id)
        {
            Pergunta proxPergunta = GetPerguntaByNumber(id + 1);
            return Json(new { titulo = proxPergunta.Titulo, descricao = proxPergunta.Descricao, numPerguntaAtual = id + 1, srcImagem = proxPergunta.ConteudoDiv });
        }

        [HttpPost]
        public IActionResult RespostaPergunta([FromBody] Resposta resposta)
        {
            Pergunta pergunta = GetPerguntaByNumber(resposta.NumPergunta);
            return Json(new { descricaoResposta = pergunta.DescricaoResposta });            
        }
    }
}