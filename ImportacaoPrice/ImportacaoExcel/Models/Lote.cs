using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoExcel.Models
{
    public class Lote
    {
        public string  Categoria { get; set; }
        public int Quantidade { get { return LotesItens.Count(); } }
        public DateTime DataCadastro { get; private set; }
        public string CaminhoArquivoExtracao { get; set; }
        public List<LoteItem> LotesItens { get; set; }


        public Lote()
        {
            LotesItens = new List<LoteItem>();
            DataCadastro = DateTime.Now;
        }
    }
}
