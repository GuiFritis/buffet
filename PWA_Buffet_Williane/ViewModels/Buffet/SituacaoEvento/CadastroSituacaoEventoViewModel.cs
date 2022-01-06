using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.ViewModels.Buffet.SituacaoConvidado
{
    public class CadastroSituacaoEventoViewModel
    {
        public SituacaoEventoEntity Situacao { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public CadastroSituacaoEventoViewModel(SituacaoEventoEntity situacoes, string msgSucesso, string msgErro)
        {
            Situacao = situacoes;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public CadastroSituacaoEventoViewModel()
        {
        }
    }
}