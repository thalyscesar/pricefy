using Api.Pricefy.BD;
using Api.Pricefy.Binders;
using Api.Pricefy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricefy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoteController : ControllerBase
    {
        private readonly ContextMongo mongo;

        public LoteController(IOptions<ConfiguracaoSistema> configuracoes)
        {
            mongo = new ContextMongo(configuracoes);
        }


        [HttpGet("{id}")]
        public LoteModel Get(string id)
        {
            var lote = mongo.Lotes.Find(l => l.Id == id).FirstOrDefault();
            return lote;
        }

        public IActionResult Get()
        {
            var models = mongo.Lotes.Find(p => true).ToEnumerable();

            if (models.Count() == 0) NotFound();
            return Ok(models);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoteModel model)
        {
            try
            {
                mongo.Lotes.InsertOne(model);
                return Ok(model.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
