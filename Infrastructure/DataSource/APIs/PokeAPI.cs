using PokedexMVVM.Domain.Entities;
using PokedexMVVM.Infrastructure.DataSource.Abstraction;
using PokedexMVVM.Infrastructure.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace PokedexMVVM.Infrastructure.DataSource.APIs
{
    public class PokeAPI : IPokemonDataSource
    {
        private readonly HttpClient? _httpClient;

        public PokeAPI()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            };

        }

        public async Task<List<Pokemon>> GetAllPokemons()
        {
            var response = await _httpClient?.GetFromJsonAsync<PokemonListDTO>("pokemon?limit=151")!;
            var pokemonList = new List<Pokemon>();
            foreach(var pokemon in response?.Results ?? new())
            {
                pokemonList.Add(new Pokemon() { Name = pokemon.Name });
            }

            return pokemonList;
        }

        public async Task<Pokemon> GetPokemonByID(int id)
        {
            var response = await _httpClient?.GetFromJsonAsync<Pokemon>($"pokemon/{id}")!;
            return response ?? new();
        }
    }
}
