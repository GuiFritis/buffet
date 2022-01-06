﻿using PWA_Buffet_Williane.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Convidado
{
    public class SituacaoConvidadoService
    {
        private readonly DatabaseContext _databaseContext;

        public SituacaoConvidadoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> ExisteDescricao(string descricao, string id)
        {
            var e = _databaseContext.SituacaoConvidado.AsQueryable();

            e = e.Where(s=>s.Descricao.Equals(descricao));

            if (!id.Equals(String.Empty))
            {
                e = e.Where(s => s.Id != new Guid(id));
            }

            return await e.AnyAsync();
        }
        
    }
}
