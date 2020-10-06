using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricefy.Models
{
    public class LoteItemModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public int? RevendaId { get; set; }
        public string RazaoSocial { get; set; }
        public int? ProdutoCodigoNaRevenda { get; set; }
        public string NomeProdutoRevenda { get; set; }
        public decimal? Fator { get; set; }
        public decimal? TamanhoEmbalagem { get; set; }
        public string CodigoProdutoDaIndustria { get; set; }
        public string NomeDoProdutoNaIndustria { get; set; }
        public int? TratamentoId { get; set; }
        public string TratamentoNome { get; set; }
        public string Observacao { get; set; }
        public bool Ignorado { get; set; }
        public bool Vinculado { get; set; }

        public LoteItemModel()
        {
          Id =  Guid.NewGuid().ToString();
        }
    }
}
