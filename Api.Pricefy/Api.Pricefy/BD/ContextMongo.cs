using Api.Pricefy.Binders;
using Api.Pricefy.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api.Pricefy.BD
{
    public class ContextMongo
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public ContextMongo(IOptions<ConfiguracaoSistema> config)
        {
            _client = new MongoClient(config.Value.ConnectionString);
            _database = _client.GetDatabase(config.Value.DatabaseName);
        }

        public IMongoCollection<LoteItemModel> LotesItens { get { return _database.GetCollection<LoteItemModel>("lotesitens"); } }

        public IMongoCollection<LoteModel> Lotes { get { return _database.GetCollection<LoteModel>("lotes"); } }


    }
}
