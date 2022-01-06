#nullable enable
using System;

namespace PWA_Buffet_Williane.RequestModels.Evento
{
    public class CadastroEventoRequestModel
    {
        public CadastroEventoRequestModel()
        {
        }

        public CadastroEventoRequestModel(string id, string nome, string cliente, string tipoEvento, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string situacaoEvento, string local, string observacoes, DateTime registroDataInsert, DateTime registroDataUpdate)
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

        public string? Id { get; set; }

        public string Nome { get; set; }

        public string Cliente { get; set; }

        public string TipoEvento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFim { get; set; }

        public string SituacaoEvento { get; set; }

        public string Local { get; set; }

        public string Observacoes { get; set; }

        public DateTime RegistroDataInsert { get; set; }

        public DateTime RegistroDataUpdate { get; set; }
    }
}