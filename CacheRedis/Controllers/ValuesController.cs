using CacheRedis.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CacheRedis.Controllers
{
    [Route("api/cacheredis")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IDistributedCache distributedCache;

        public ValuesController(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        // GET api/cacheredis/
        [HttpGet]        
        public ActionResult<string> Get()
        {
            var cacheKey = "categories";

            var existingCategories = distributedCache.GetString(cacheKey);

            if (!string.IsNullOrEmpty(existingCategories))
            {
                var retorno = JsonConvert.DeserializeObject(existingCategories);
                return retorno.ToString();
            }
            else
            {
                var category = new Category("NOVA CATEGORIA NO REDIS");

                string categoryJson = JsonConvert.SerializeObject(category);

                distributedCache.SetString(cacheKey, categoryJson);

                return JsonConvert.SerializeObject(category); 

            }
        }

        
    }
}
