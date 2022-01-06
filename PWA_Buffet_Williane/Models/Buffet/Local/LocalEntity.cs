using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Local
{
    public class LocalEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
    }
}
