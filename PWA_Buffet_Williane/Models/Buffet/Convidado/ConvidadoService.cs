using PWA_Buffet_Williane.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Convidado
{
    public class ConvidadoService
    {
        private readonly DatabaseContext _databaseContext;

        public ConvidadoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<List<ConvidadoEntity>> GetConvidadosEvento(EventoEntity evento)
        {
            return _databaseContext.Convidado.
                Where(c => c.Evento.Equals(evento)).Include(c => c.SituacaoConvidado).ToList();
        }
        
        public async void DeleteConvidadosEvento(EventoEntity evento)
        {
            _databaseContext.Convidado.RemoveRange(await GetConvidadosEvento(evento));
        }
        
        public async Task<bool> ExisteCpf(string cpf, Guid evento)
        {
            return _databaseContext.Convidado.
                Where(c => c.CPF.Equals(cpf)).
                Any(c => c.Evento.Id.Equals(evento));
        }
        
        public bool existeCPF(string cpf)
        {
            var query = _databaseContext.Convidado.
                Where(c => c.CPF.Equals(cpf)).ToList();

            return query.Any();
        }
        
    }
}
