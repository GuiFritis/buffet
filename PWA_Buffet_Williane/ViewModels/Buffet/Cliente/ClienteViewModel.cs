using System;
using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.ViewModels.Buffet.Cliente
{
    public class ClienteViewModel
    {
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }
        public ICollection<ClientePF> ListaClientesPF { get; set; }
        public ICollection<ClientePJ> ListaClientesPJ { get; set; }
        public ClienteEntity Cliente { get; set; }
        public Filtros Filtros { get; set; }
       
        public ClienteViewModel()
        {
            ListaClientesPF = new List<ClientePF>();
            ListaClientesPJ = new List<ClientePJ>();
            Cliente = new ClienteEntity();
        }
    }
    
    public class ClientePF
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        
        public ICollection<EventoEntity> Eventos { get; set; }
    }
    
    public class ClientePJ
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public string CNPJ { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
    }
    
    public class Filtros
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
    }
}