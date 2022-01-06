using System;

namespace PWA_Buffet_Williane.RequestModels
{
    public class FiltroListagemClientes
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public string CNPJ { get; set; }
    }
}