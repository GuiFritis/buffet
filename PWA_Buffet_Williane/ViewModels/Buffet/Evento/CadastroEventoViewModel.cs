using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;
using PWA_Buffet_Williane.ViewModels.Buffet.Local;

namespace PWA_Buffet_Williane.ViewModels
{
    public class CadastroEventoViewModel
    {
        public EventoEntity EventoEntity { get; set; }
        public List<LocalEntity> Locais { get; set; }
        public List<ConvidadoEntity> Convidados { get; set; }
        public List<SituacaoEventoEntity> Situacao { get; set; }
        public List<TipoEventoEntity> TipoEvento { get; set; }
        public List<ClienteEntity> Clientes { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public CadastroEventoViewModel(EventoEntity eventoEntity, List<LocalEntity> locais, List<ConvidadoEntity> convidados, List<SituacaoEventoEntity> situacao, List<TipoEventoEntity> tipoEvento, List<ClienteEntity> clientes, string msgSucesso, string msgErro)
        {
            EventoEntity = eventoEntity;
            Locais = locais;
            Convidados = convidados;
            Situacao = situacao;
            TipoEvento = tipoEvento;
            Clientes = clientes;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public CadastroEventoViewModel()
        {
        }
    }
}