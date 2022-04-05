using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhaAgendaVer1.Models;
using MinhaAgendaVer1.Repositorio;

namespace MinhaAgendaVer1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmail(loginModel.Email);

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {

                            return RedirectToAction("Index", "Usuario");

                        }
                        TempData["MensagemErro"] = $"Senha inválida.";
                    }

                    TempData["MensagemErro"] = $"Usuário ou senha inválida.";
                }

                return View("Index");

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
