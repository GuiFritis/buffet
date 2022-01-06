using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.TipoEvento
{
    public class TipoEventoService
    {
        private readonly DatabaseContext _databaseContext;

        public TipoEventoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    
        public List<TipoEventoEntity> ObterTiposDeEvento()
        {
            var listaLocais = _databaseContext.TipoEvento.AsQueryable();
            
            return listaLocais.ToList();
        }
    
        public bool existeTipoEvento(Guid? id, string descricao)
        {
            var query = _databaseContext.TipoEvento.
                Where(t => t.Descricao.Equals(descricao) && t.Id != id).ToList();

            return query.Any();
        }

        public List<EventoEntity> getEventosTipoEvento(Guid id)
        {
            var eventosTipoEvento = _databaseContext.Evento
                .Include(e => e.TipoEvento)
                .Where(e => e.TipoEvento.Id == id);

            return eventosTipoEvento.ToList();
        }
    }
}