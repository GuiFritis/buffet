using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Models.Acesso;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;

namespace PWA_Buffet_Williane.Data
{
    public class DatabaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<EventoEntity> Evento { get; set; }
        public DbSet<ConvidadoEntity> Convidado { get; set; }
        public DbSet<LocalEntity> Local { get; set; }
        public DbSet<SituacaoEventoEntity> SituacaoEvento { get; set; }
        public DbSet<SituacaoConvidadoEntity> SituacaoConvidado { get; set; }
        public DbSet<TipoClienteEntity> TipoCliente { get; set; }
        public DbSet<TipoEventoEntity> TipoEvento { get; set; }
        public DbSet<HistoricoLoginEntity> HistoricoLogin { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}
