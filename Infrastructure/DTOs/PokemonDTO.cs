using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexMVVM.Infrastructure.DTOs
{
    /// <summary>  
    /// Data transfer object representing a Pokemon.  
    /// </summary>  
    public class PokemonDTO
    {
        /// <summary>  
        /// Gets or sets the name of the Pokemon.  
        /// </summary>  
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    /// <summary>  
    /// Data transfer object representing a list of Pokemons.  
    /// </summary>  
    public class PokemonListDTO
    {
        /// <summary>  
        /// Gets or sets the list of Pokemon data transfer objects.  
        /// </summary>  
        [JsonProperty("results")]
        public List<PokemonDTO>? Results { get; set; }
    }
}
