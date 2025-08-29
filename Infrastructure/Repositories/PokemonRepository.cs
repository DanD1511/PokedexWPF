using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Domain.Entities;
using PokedexMVVM.Infrastructure.DataSource.Abstraction;

namespace PokedexMVVM.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemonDataSource? _pokemonDataSource;

        public PokemonRepository(IPokemonDataSource pokemonDataSource)
        {
            _pokemonDataSource = pokemonDataSource;
        }

        public async Task<List<Pokemon>> GetAllPokemons()
        {
            return await _pokemonDataSource?.GetAllPokemons() ?? new List<Pokemon>();
        }

        public async Task<Pokemon> GetPokemonByID(int id)
        {
            return await _pokemonDataSource?.GetPokemonByID(id) ?? new();
        }
    }
}
