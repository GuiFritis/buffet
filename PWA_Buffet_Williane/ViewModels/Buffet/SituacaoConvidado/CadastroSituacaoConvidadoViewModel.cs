using PWA_Buffet_Williane.Models.Buffet.Convidado;

namespace PWA_Buffet_Williane.ViewModels.Buffet.SituacaoConvidado
{
    public class CadastroSituacaoConvidadoViewModel
    {
        public SituacaoConvidadoEntity Situacao { get; set; }
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }

        public CadastroSituacaoConvidadoViewModel(SituacaoConvidadoEntity situacoes, string msgSucesso, string msgErro)
        {
            Situacao = situacoes;
            MsgSucesso = msgSucesso;
            MsgErro = msgErro;
        }

        public CadastroSituacaoConvidadoViewModel()
        {
        }
    }
}