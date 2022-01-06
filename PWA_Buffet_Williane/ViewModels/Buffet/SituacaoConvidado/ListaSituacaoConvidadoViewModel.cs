using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Convidado;

namespace PWA_Buffet_Williane.ViewModels.Buffet.SituacaoConvidado
{
    public class ListaSituacaoConvidadoViewModel
    {
        public List<SituacaoConvidadoEntity> Situacoes { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public ListaSituacaoConvidadoViewModel(List<SituacaoConvidadoEntity> situacoes, string msgSucesso, string msgErro)
        {
            Situacoes = situacoes;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public ListaSituacaoConvidadoViewModel()
        {
        }
    }
}