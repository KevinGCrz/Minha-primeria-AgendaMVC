using Microsoft.EntityFrameworkCore;
using MinhaAgendaVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<EventoModel> Eventos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

// SCRIPTS DE INICIAÇÃO DE MIGRATION
//
// Add-Migration CriandoTabelaEventos -Context BancoContext
// Update-Database -Context BancoContext