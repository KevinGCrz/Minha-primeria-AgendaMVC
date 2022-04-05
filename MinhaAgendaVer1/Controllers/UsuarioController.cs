using Microsoft.AspNetCore.Mvc;
using MinhaAgendaVer1.Models;
using MinhaAgendaVer1.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly IEventoRepositorio _eventoRepositorio;
        public UsuarioController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }


        public IActionResult Index()
        {
            List<EventoModel> eventos = _eventoRepositorio.BuscarTodos();

            return View(eventos);
        }

        public IActionResult Criar()
        {

            return View();
        }

        public IActionResult Editar(int id)
        {
            EventoModel evento = _eventoRepositorio.ListarPorId(id);
            return View(evento);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            EventoModel evento = _eventoRepositorio.ListarPorId(id);
            return View(evento);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = _eventoRepositorio.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Evento deletado com sucesso!";
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
        public IActionResult Criar(EventoModel evento)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    _eventoRepositorio.Adicionar(evento);
                    TempData["MensagemSucesso"] = "Evento agendado com sucesso!";
                    return RedirectToAction("Index");

                //Teste condicional de datas - teste 1 falho

                //    if (evento.Tipo != "Exclusivo" && evento.Data == evento.Data)
                //    {
                //        _eventoRepositorio.Adicionar(evento);
                //        TempData["MensagemSucesso"] = "Evento agendado com sucesso!";
                //        return RedirectToAction("Index");
                //    }
                    
                }

                return View(evento);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(EventoModel evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eventoRepositorio.Atualizar(evento);
                    TempData["MensagemSucesso"] = "Evento Alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", evento);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algum erro ocorreu, tente novamente! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }

}
