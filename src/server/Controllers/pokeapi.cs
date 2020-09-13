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
        private List<Models.PokeType> _types = null;

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
            var pokeomns = JsonUtility.Deserialize<IEnumerable<Models.Pokemon>>(jsonString);
            //foreach (var pokemon in pokeomns)
            //{
            //    for (var i = 0; i < pokemon.type.Length; i++)
            //    {
            //        pokemon.type[i] = translateType(pokemon.type[i]);
            //    }
            //}
            return pokeomns.ToArray();
        }


        [HttpGet("{id}")]
        public Models.Pokemon Get(int id)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Models.Pokemon>));

            string jsonString;
            using (var reader = new System.IO.StreamReader(@"pokemon.json/pokedex.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            var pokemon = JsonUtility.Deserialize<List<Models.Pokemon>>(jsonString).Where(item => item.id.Equals(id)).ToList()[0];
            for (var i = 0; i < pokemon.type.Length; i++)
            {
                pokemon.type[i] = translateType(pokemon.type[i]);
            }
            return pokemon;
        }

        private string translateType(string type)
        {
            if (_types == null)
            {
                _types = getPoketypes();
            }
            var applicableType = _types.Where(item => item.english.Equals(type)).FirstOrDefault();
            if (applicableType == null)
            {
                return type;
            }
            return applicableType .japanese;
            
        }
        private List<Models.PokeType> getPoketypes()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Models.PokeType>));
            string jsonString;
            using (var reader = new System.IO.StreamReader(@"pokemon.json/types.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            return JsonUtility.Deserialize<List<Models.PokeType>>(jsonString);
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
