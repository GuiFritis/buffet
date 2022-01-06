using System;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Models.Acesso
{
    public class HistoricoLoginEntity
    {
        public HistoricoLoginEntity()
        {
            Id = new Guid();
        }
        
        public HistoricoLoginEntity(Guid id, DateTime dataHoraLogin, Usuario usuario)
        {
            Id = id;
            DataHoraLogin = dataHoraLogin;
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public DateTime DataHoraLogin { get; set; }
        public Usuario Usuario { get; set; }
    }
}