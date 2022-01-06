namespace PWA_Buffet_Williane.RequestModels
{
    public class SituacaoTipoRequestModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }

        public SituacaoTipoRequestModel(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public SituacaoTipoRequestModel()
        {
        }
    }
}