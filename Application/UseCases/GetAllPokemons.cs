using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Application.UseCases
{
    /// <summary>  
    /// Use case for retrieving all Pokemons.  
    /// </summary>  
    public class GetAllPokemons
    {
        private readonly IPokemonRepository _pokemonRepository;

        /// <summary>  
        /// Initializes a new instance of the <see cref="GetAllPokemons"/> class.  
        /// </summary>  
        /// <param name="pokemonRepository">The repository to access Pokemon data.</param>  
        public GetAllPokemons(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        /// <summary>  
        /// Retrieves a list of all available Pokemons asynchronously.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of Pokemon entities.</returns>  
        public async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            return await _pokemonRepository?.GetAllPokemons()!;
        }
    }
}
