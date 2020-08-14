using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace PokeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class pokeapiController : ControllerBase
    {
        private readonly ILogger<pokeapiController> _logger;

        public pokeapiController(ILogger<pokeapiController> logger)
        {
            _logger = logger;
        }
    
        [HttpGet]
        public IEnumerable<Models.Pokemon> Get()
        {
            var serializer = new DataContractJsonSerializer(typeof(IEnumerable<Models.Pokemon>));
            
            string jsonString;
            using (var reader = new System.IO.StreamReader(@"pokemon.json/pokedex.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            return JsonUtility.Deserialize<IEnumerable<Models.Pokemon>>(jsonString).ToArray();
        }


        [HttpGet("{id}")]
        public IEnumerable<Models.Pokemon> Get(int id)
        {
            var serializer = new DataContractJsonSerializer(typeof(IEnumerable<Models.Pokemon>));
            
            string jsonString;
            using (var reader = new System.IO.StreamReader(@"pokemon.json/pokedex.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            return JsonUtility.Deserialize<IEnumerable<Models.Pokemon>>(jsonString)
            .Where(e => (e.id.Equals(id))).ToArray();
        }
    }

    public static class JsonUtility
    {
        /// <summary>
        /// Jsonメッセージをオブジェクトへデシリアライズします。
        /// </summary>
        public static T Deserialize<T>(string message)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
            {
                //var setting = new DataContractJsonSerializerSettings()
                //{
                //    UseSimpleDictionaryFormat = true,
                //};
                var serializer = new DataContractJsonSerializer(typeof(T)/*, setting*/);
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
