using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using phishing.Data;
using Microsoft.AspNetCore.Mvc;
using phishing.Models.ViewModels;

namespace phishing.Controllers
{
    public class ResultadoController : Controller
    {
        public IActionResult Resultado()
        {
            ResultadoViewModel resultado = new ResultadoViewModel()
            {
                Acertos = Convert.ToInt32(TempData["pontuacao"]),
                Usuario = new Models.Usuario() { Nome = TempData["nome"].ToString(), Email = TempData["email"].ToString() }
            };
            
            Bd_Conexao bd_Conexao = new Bd_Conexao();
            bd_Conexao.gravarPontuacao(resultado.Usuario.Nome, resultado.Usuario.Email, resultado.Acertos);

            return View(resultado);
        }

    }
}