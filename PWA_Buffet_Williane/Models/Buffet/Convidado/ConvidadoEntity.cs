using PWA_Buffet_Williane.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        public ConvidadoEntity()
        {
            Id = new Guid();
        }

        public ConvidadoEntity(Guid id, string nome, string email, string cPF, DateTime dataNasc, EventoEntity evento, SituacaoConvidadoEntity situacaoConvidado, string observacoes, DateTime registroDataInsert, DateTime? registroDataUpdate)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cPF;
            DataNasc = dataNasc;
            Evento = evento;
            SituacaoConvidado = situacaoConvidado;
            Observacoes = observacoes;
            RegistroDataInsert = registroDataInsert;
            RegistroDataUpdate = registroDataUpdate;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        public EventoEntity Evento { get; set; }

        [Display(Name = "Situação do Convidado")]
        public SituacaoConvidadoEntity SituacaoConvidado { get; set; }

        public string Observacoes { get; set; }

        [Required]
        [Display(Name = "Data de Inserção do Registro")]
        public DateTime RegistroDataInsert { get; set; }

        [Display(Name = "Data de Alteração do Registro")]
        public DateTime? RegistroDataUpdate { get; set; }
    }
}
