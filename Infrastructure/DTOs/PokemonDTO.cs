using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexMVVM.Infrastructure.DTOs
{
    public class PokemonDTO
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class PokemonListDTO
    {
        [JsonProperty("results")]
        public List<PokemonDTO>? Results { get; set; }
    }
}
