using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.ViewModels.Buffet.SituacaoConvidado
{
    public class ListaSituacaoEventoViewModel
    {
        public List<SituacaoEventoEntity> Situacoes { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public ListaSituacaoEventoViewModel(List<SituacaoEventoEntity> situacoes, string msgSucesso, string msgErro)
        {
            Situacoes = situacoes;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public ListaSituacaoEventoViewModel()
        {
        }
    }
}