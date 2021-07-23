using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockInSenai_ARKDREAL.Models;

namespace RockInSenai_ARKDREAL.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }

        public IActionResult Index()
        {
            return View();
        }
           Musico m = new Musico();

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            bool loginConfirmado = m.Logar(form["Email"], form["Senha"]);

            if (loginConfirmado == true)
            {
                return LocalRedirect("~/");
            }

            return LocalRedirect("~/Login");
        }
    }
}