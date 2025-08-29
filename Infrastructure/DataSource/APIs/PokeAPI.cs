using PokedexMVVM.Domain.Entities;
using PokedexMVVM.Infrastructure.DataSource.Abstraction;
using PokedexMVVM.Infrastructure.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace PokedexMVVM.Infrastructure.DataSource.APIs
{
    /// <summary>  
    /// Implementation of <see cref="IPokemonDataSource"/> that interacts with the PokeAPI to retrieve Pokemon data.  
    /// </summary>  
    public class PokeAPI : IPokemonDataSource
    {
        private readonly HttpClient? _httpClient;

        /// <summary>  
        /// Initializes a new instance of the <see cref="PokeAPI"/> class.  
        /// </summary>  
        /// <param name="httpClient">The HTTP client used to send requests to the PokeAPI.</param>  
        public PokeAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>  
        /// Retrieves a list of all available Pokemons from the PokeAPI.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Pokemon"/> entities.</returns>  
        public async Task<List<Pokemon>> GetAllPokemons()
        {
            var response = await _httpClient?.GetFromJsonAsync<PokemonListDTO>("pokemon?limit=151")!;
            var pokemonList = new List<Pokemon>();
            foreach (var pokemon in response?.Results ?? new())
            {
                pokemonList.Add(new Pokemon() { Name = pokemon.Name });
            }

            return pokemonList;
        }

        /// <summary>  
        /// Retrieves a Pokemon by its unique identifier from the PokeAPI.  
        /// </summary>  
        /// <param name="id">The unique identifier of the Pokemon.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Pokemon"/> entity.</returns>  
        public async Task<Pokemon> GetPokemonByID(int id)
        {
            var response = await _httpClient?.GetFromJsonAsync<Pokemon>($"pokemon/{id}")!;
            return response ?? new();
        }
    }
}
