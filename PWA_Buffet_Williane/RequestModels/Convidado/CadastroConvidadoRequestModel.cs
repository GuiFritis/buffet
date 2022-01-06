#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.RequestModels.Convidado
{
    public class CadastroConvidadoRequestModel
    {
        public string? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public string Evento { get; set; }
        public string SituacaoConvidado { get; set; }
        public string Observacoes { get; set; }
        public DateTime RegistroDataInsert { get; set; }
        public DateTime? RegistroDataUpdate { get; set; }

        public CadastroConvidadoRequestModel()
        {
        }

        public CadastroConvidadoRequestModel(string id, string nome, string email, string cpf, DateTime dataNasc, string evento, string situacaoConvidado, string observacoes, DateTime registroDataInsert, DateTime? registroDataUpdate)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
            DataNasc = dataNasc;
            Evento = evento;
            SituacaoConvidado = situacaoConvidado;
            Observacoes = observacoes;
            RegistroDataInsert = registroDataInsert;
            RegistroDataUpdate = registroDataUpdate;
        }
    }
}