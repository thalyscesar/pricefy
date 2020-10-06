using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoExcel.Models
{
    public class LoteItem
    {
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
    }
}
