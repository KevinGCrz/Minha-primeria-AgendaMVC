using Microsoft.AspNetCore.Mvc;
using MinhaAgendaVer1.Models;
using MinhaAgendaVer1.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Controllers
{
    public class CadastroController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CadastroController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _usuarioRepositorio = UsuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> Usuarios = _usuarioRepositorio.BuscarTodos();

            return View(Usuarios);

        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, algum erro ocorreu, tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Bem-vindo a sua agenda!";
                    return RedirectToAction("Index", "Login");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Perfil atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }

}
