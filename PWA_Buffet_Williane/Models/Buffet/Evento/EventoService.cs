using PWA_Buffet_Williane.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.RequestModels.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Evento
{
    public class EventoService
    {
        private readonly DatabaseContext _databaseContext;

        public EventoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<EventoEntity>> GetEventosFiltro(FiltroEvento filtros)
        {
            var eventos = _databaseContext.Evento.AsQueryable();

            if (filtros.FiltroNome != null)
            {
                eventos = eventos.Where(e => e.Nome.Contains(filtros.FiltroNome));
            }

            if (filtros.FiltroLocal != null)
            {
                eventos = eventos.Where(e => e.Local.Id.ToString().Equals(filtros.FiltroLocal));
            }

            if (filtros.FiltroSituacao != null)
            {
                eventos = eventos.Where(e => e.SituacaoEvento.Id.ToString().Equals(filtros.FiltroSituacao));
            }
            
            if (filtros.FiltroTipo != null)
            {
                eventos = eventos.Where(e => e.TipoEvento.Id.Equals(new Guid(filtros.FiltroTipo)));
            }

            return eventos.ToList();

        }

        public async Task<bool> DataLivre(EventoEntity evento)
        {
            var d =  _databaseContext.Evento.AsQueryable();
            d = d.Where(e => e.Local.Id.Equals(evento.Local.Id));
            d = d.Where(e => e.DataHoraInicio.CompareTo(evento.DataHoraFim.AddHours(24)) < 0);
            d = d.Where(e => e.DataHoraFim.CompareTo(evento.DataHoraInicio.AddHours(-24)) > 0);
            d = d.Where(e => e.Id != evento.Id);
            
            return await d.AnyAsync();
        }
    }
}
