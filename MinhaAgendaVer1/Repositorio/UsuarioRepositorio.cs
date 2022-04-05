using MinhaAgendaVer1.Data;
using MinhaAgendaVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorEmail(string email)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {

            // gravar no banco os eventos
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização de seu cadastro!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.DataNascimento = usuario.DataNascimento;
            usuarioDB.Sexo = usuario.Sexo;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na exclusão do seu cadastro!");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        
    }
}
