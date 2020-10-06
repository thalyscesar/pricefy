using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CustomUI;
using ImportacaoExcel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ImportacaoExcel
{
    public class Program
    {

        public static void Main(string[] args)
        {
           var pasta = System.IO.Directory.GetCurrentDirectory();

            var nomesArquivos = new List<string> { "lote1.xlsx", "lote2.xlsx" };

            foreach (var nomeArquivo in nomesArquivos)
            {
                string caminho = $"{pasta}\\Lotes\\{nomeArquivo}";
                new ImportacaoExcel().ExecuteImportacao(caminho);
            }

            Console.WriteLine("Importação realizada com sucesso");
            Console.ReadLine();
        }

        public class ImportacaoExcel
        {
            private readonly string UrlApi = "http://localhost:49163";

            public  void ExecuteImportacao(string caminho)
            {
                if (!System.IO.File.Exists(caminho))
                {
                    throw new Exception("Arquivo para extração não foi encontrado");
                }

                using (XLWorkbook workBook = new XLWorkbook(caminho))
                {
                    IXLWorksheet workSheet = workBook.Worksheet(1);

                    bool EhPrimeiraLinha = true;
                    List<LoteItem> loteItems = new List<LoteItem>();
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        if (EhPrimeiraLinha)
                            EhPrimeiraLinha = false;
                        else
                        {
                            LoteItem item = new LoteItem();
                            item.RevendaId = row.Cell(1).GetString().ToInt();
                            item.RazaoSocial = row.Cell(2).GetValue<string>().Trim();
                            item.ProdutoCodigoNaRevenda = row.Cell(3).GetString().ToInt();
                            item.NomeProdutoRevenda = row.Cell(4).GetValue<string>().Trim();
                            item.Fator = row.Cell(5).Value.ToDecimal();
                            item.TamanhoEmbalagem = row.Cell(6).Value.ToDecimal();
                            item.CodigoProdutoDaIndustria = row.Cell(7).GetString().Trim();
                            item.NomeDoProdutoNaIndustria = row.Cell(8).GetString().Trim();
                            item.TratamentoId = row.Cell(9).Value.ToInt();
                            item.TratamentoNome = row.Cell(10).GetValue<string>().Trim();
                            item.Observacao = row.Cell(11).GetValue<string>().Trim();
                            item.Ignorado = row.Cell(12).GetValue<string>().ToBool();
                            item.Vinculado = row.Cell(13).GetValue<string>().ToBool();
                            loteItems.Add(item);
                        }
                    }

                    Lote lote = new Lote();
                    lote.CaminhoArquivoExtracao = caminho;
                    lote.Categoria = "Lote de produto Empresa VS Revenda";
                    lote.LotesItens = loteItems;

                    if (!SalvarLoteProduto(lote))
                    {
                        throw new Exception("Erro ao salvar lote de produto  ocorreu uma inconsistencia verifique o arquivo: " + caminho);
                    }
                }
            }

            public bool SalvarLoteProduto(Lote lote)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(UrlApi);
                    client.Timeout = TimeSpan.FromMinutes(7);
                    var json = JsonConvert.SerializeObject(lote);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("api/lote", content).Result;
                    return result.IsSuccessStatusCode;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
