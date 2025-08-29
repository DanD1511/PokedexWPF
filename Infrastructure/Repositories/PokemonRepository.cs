using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Domain.Entities;
using PokedexMVVM.Infrastructure.DataSource.Abstraction;

namespace PokedexMVVM.Infrastructure.Repositories
{
    /// <summary>  
    /// Repository implementation for managing Pokemon data.  
    /// Provides methods to retrieve Pokemon data from a data source.  
    /// </summary>  
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemonDataSource? _pokemonDataSource;

        /// <summary>  
        /// Initializes a new instance of the <see cref="PokemonRepository"/> class.  
        /// </summary>  
        /// <param name="pokemonDataSource">The data source to retrieve Pokemon data from.</param>  
        public PokemonRepository(IPokemonDataSource pokemonDataSource)
        {
            _pokemonDataSource = pokemonDataSource;
        }

        /// <summary>  
        /// Retrieves a list of all available Pokemons asynchronously.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Pokemon"/> entities.</returns>  
        public async Task<List<Pokemon>> GetAllPokemons()
        {
            return await _pokemonDataSource?.GetAllPokemons() ?? new List<Pokemon>();
        }

        /// <summary>  
        /// Retrieves a Pokemon by its unique identifier asynchronously.  
        /// </summary>  
        /// <param name="id">The unique identifier of the Pokemon.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Pokemon"/> entity.</returns>  
        public async Task<Pokemon> GetPokemonByID(int id)
        {
            return await _pokemonDataSource?.GetPokemonByID(id) ?? new();
        }
    }
}
