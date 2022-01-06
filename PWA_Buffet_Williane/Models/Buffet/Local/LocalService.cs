using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Local
{
    public class LocalService
    {
        private readonly DatabaseContext _databaseContext;

        public LocalService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<LocalEntity> ObterLocaisComFiltro(string filtroDescricao, string filtroEndereco)
        {
            var listaLocais = _databaseContext.Local
                .Include(l => l.Eventos)
                .AsQueryable();

            if (filtroDescricao != null)
            {
                listaLocais = listaLocais.Where(l => l.Descricao.Contains(filtroDescricao));
            }

            if (filtroEndereco != null)
            {
                listaLocais = listaLocais.Where(l => l.Endereco.Contains(filtroEndereco));
            }
            
            return listaLocais.ToList();
        }
        
        public bool existeLocal(Guid? id, string descricao)
        {

            var query = _databaseContext.Local.
                Where(l => l.Descricao.Equals(descricao) && l.Id != id).ToList();

            return query.Any();
        }

        public LocalEntity getLocalById(Guid? id)
        {
            var queryEvento = _databaseContext.Evento
                .Include(e => e.SituacaoEvento)
                .Include(e => e.TipoEvento)
                .Include(e => e.Local)
                .Include(e => e.Cliente)
                .Where(e => e.Local.Id.Equals(id));

            List<EventoEntity> eventos = queryEvento.ToList();
            
            var query = _databaseContext.Local
                .Where(l => l.Id.Equals(id));

            LocalEntity local = query.First();
            local.Eventos = eventos;
            
            return local;
        }
    }
}