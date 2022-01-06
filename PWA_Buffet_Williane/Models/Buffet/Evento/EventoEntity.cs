using PWA_Buffet_Williane.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;

namespace PWA_Buffet_Williane.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public EventoEntity()
        {
            Id = new Guid();
        }

        public EventoEntity(Guid id, string nome, ClienteEntity cliente, TipoEventoEntity tipoEvento, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, SituacaoEventoEntity situacaoEvento, LocalEntity local, string observacoes, DateTime registroDataInsert, DateTime? registroDataUpdate)
        {
            Id = id;
            Nome = nome;
            Cliente = cliente;
            TipoEvento = tipoEvento;
            Descricao = descricao;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            SituacaoEvento = situacaoEvento;
            Local = local;
            Observacoes = observacoes;
            RegistroDataInsert = registroDataInsert;
            RegistroDataUpdate = registroDataUpdate;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ClienteEntity Cliente { get; set; }

        [Display(Name = "Tipo de Evento")]
        public TipoEventoEntity TipoEvento { get; set; }

        public string Descricao { get; set; }

        [Display(Name = "Data e Horário de Início")]
        public DateTime DataHoraInicio { get; set; }

        [Display(Name = "Data e Horário de Término")]
        public DateTime DataHoraFim { get; set; }

        [Display(Name = "Situação do Evento")]
        public SituacaoEventoEntity SituacaoEvento { get; set; }

        public LocalEntity Local { get; set; }

        public string Observacoes { get; set; }

        [Required]
        [Display(Name = "Data de Inserção do Registro")]
        public DateTime RegistroDataInsert { get; set; }

        [Display(Name = "Data de Alteração do Registro")]
        public DateTime? RegistroDataUpdate { get; set; }

    }
}
