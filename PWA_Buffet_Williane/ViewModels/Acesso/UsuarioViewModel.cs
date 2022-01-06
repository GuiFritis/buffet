using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Acesso;
using PWA_Buffet_Williane.RequestModels;

namespace PWA_Buffet_Williane.ViewModels.Acesso
{
    public class UsuarioViewModel
    {
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }
        public Usuario Usuario { get; set; }
        public string SenhaAtual { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public ICollection<HistoricoLoginEntity> HistoricoLoginUser { get; set; }
        
        public UsuarioViewModel()
        {
            HistoricoLoginUser = new List<HistoricoLoginEntity>();
            Usuario = new Usuario();
        }
    }
}