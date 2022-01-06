using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.ViewModels.Buffet.Convidado
{
    public class CadastroConvidadoViewModel
    {
        public EventoEntity Evento { get; set; }
        public List<SituacaoConvidadoEntity> Situacoes { get; set; }
        public ConvidadoEntity Convidado { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public CadastroConvidadoViewModel(EventoEntity evento, List<SituacaoConvidadoEntity> situacoes, ConvidadoEntity convidado, string msgErro, string msgSuccesso)
        {
            Evento = evento;
            Situacoes = situacoes;
            Convidado = convidado;
            MsgErro = msgErro;
            MsgSucesso = msgSuccesso;
        }

        public CadastroConvidadoViewModel()
        {
        }
    }
}