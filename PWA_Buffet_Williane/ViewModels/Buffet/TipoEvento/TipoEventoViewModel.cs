using System;
using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;

namespace PWA_Buffet_Williane.ViewModels.Buffet.TipoEvento
{
    public class TipoEventoViewModel
    {
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }
        public ICollection<TipoEvento> ListaTiposDeEvento { get; set; }
        public TipoEventoEntity TipoEvento { get; set; }
        public TipoEventoViewModel()
        {
            ListaTiposDeEvento = new List<TipoEvento>();
            TipoEvento = new TipoEventoEntity();
        }
    }

    public class TipoEvento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}