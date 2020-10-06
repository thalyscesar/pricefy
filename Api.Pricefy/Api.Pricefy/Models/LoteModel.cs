
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


namespace Api.Pricefy.Models
{
    public class LoteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string  Id { get; private  set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get;  set; }
        public string CaminhoArquivoExtracao { get; set; }

        public LoteModel()
        {
           Id = DateTime.Now.ToString("dd-MM-yyyy H:mm:ss.fff");
        }

        public List<LoteItemModel> LotesItens { get; set; }
    }
}
