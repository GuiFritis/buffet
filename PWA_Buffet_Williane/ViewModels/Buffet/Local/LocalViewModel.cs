using System;
using System.Collections.Generic;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.Local;

namespace PWA_Buffet_Williane.ViewModels.Buffet.Local
{
    public class LocalViewModel
    {
        public string MsgSucesso { get; set; }
        public string MsgErro { get; set; }
        public ICollection<Local> ListaLocais { get; set; }
        public LocalEntity Local { get; set; }
        public Filtros Filtros { get; set; }

        public LocalViewModel()
        {
            ListaLocais = new List<Local>();
            Local = new LocalEntity();
        }
    }

    public class Local
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
    }

    public class Filtros
    {
        public string Descricao { get; set; }
        public string Endereco { get; set; }
    }
}