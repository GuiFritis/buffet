using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.RequestModels.Evento;

namespace PWA_Buffet_Williane.ViewModels
{
    public class ListaEventoViewModel
    {
        public List<EventoEntity> Eventos { get; set; }
        public FiltroEvento FiltroEvento { get; set; }
        public List<LocalEntity> Locais { get; set; }
        public List<SituacaoEventoEntity> Situacao { get; set; }
        public List<TipoEventoEntity> TipoEvento { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public ListaEventoViewModel(List<EventoEntity> eventos, FiltroEvento filtroEvento, List<LocalEntity> locais, List<SituacaoEventoEntity> situacao, List<TipoEventoEntity> tipoEvento, string msgSucesso, string msgErro)
        {
            Eventos = eventos;
            FiltroEvento = filtroEvento;
            Locais = locais;
            Situacao = situacao;
            TipoEvento = tipoEvento;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public ListaEventoViewModel()
        {
        }
    }
}