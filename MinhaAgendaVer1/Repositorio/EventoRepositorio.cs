using MinhaAgendaVer1.Data;
using MinhaAgendaVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Repositorio
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public EventoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EventoModel ListarPorId(int id)
        {
            return _bancoContext.Eventos.FirstOrDefault(x => x.Id == id);
        }

        public List<EventoModel> BuscarTodos()
        {
            return _bancoContext.Eventos.ToList();
        }

        public EventoModel Adicionar(EventoModel evento)
        {
            // gravar no banco os eventos
            _bancoContext.Eventos.Add(evento);
            _bancoContext.SaveChanges();
            return evento;
        }

        public EventoModel Atualizar(EventoModel evento)
        {
            EventoModel eventoDB = ListarPorId(evento.Id);

            if (eventoDB == null) throw new System.Exception("Houve um erro na atualização de seu evento!");

            eventoDB.Tipo = evento.Tipo;
            eventoDB.Nome = evento.Nome;
            eventoDB.Descricao = evento.Descricao;
            eventoDB.Data = evento.Data;
            eventoDB.Local = evento.Local;
            eventoDB.Participantes = evento.Participantes;

            _bancoContext.Eventos.Update(eventoDB);
            _bancoContext.SaveChanges();

            return eventoDB;
        }

        public bool Apagar(int id)
        {
            EventoModel eventoDB = ListarPorId(id);

            if (eventoDB == null) throw new System.Exception("Houve um erro na exclusão do seu evento!");

            _bancoContext.Eventos.Remove(eventoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
