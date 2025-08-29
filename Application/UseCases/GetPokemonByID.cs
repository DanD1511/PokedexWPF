using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Application.UseCases
{
    /// <summary>  
    /// Use case for retrieving a Pokemon by its unique identifier.  
    /// </summary>  
    public class GetPokemonByID
    {
        private readonly IPokemonRepository? _pokemonRepository;

        /// <summary>  
        /// Initializes a new instance of the <see cref="GetPokemonByID"/> class.  
        /// </summary>  
        /// <param name="pokemonRepository">The repository to access Pokemon data.</param>  
        public GetPokemonByID(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        /// <summary>  
        /// Retrieves a Pokemon by its unique identifier asynchronously.  
        /// </summary>  
        /// <param name="id">The unique identifier of the Pokemon.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the Pokemon entity.</returns>  
        /// <exception cref="ApplicationException">Thrown when an error occurs while fetching the Pokemon.</exception>  
        public async Task<Pokemon> GetPokemonByIDAsync(int id)
        {
            try
            {
                return await _pokemonRepository!.GetPokemonByID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching Pokemon with ID {id}", ex);
            }
        }
    }
}
