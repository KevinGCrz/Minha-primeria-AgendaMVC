using MinhaAgendaVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmail(string email);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel evento);
        UsuarioModel Atualizar(UsuarioModel evento);
        bool Apagar(int id);
    }
}
