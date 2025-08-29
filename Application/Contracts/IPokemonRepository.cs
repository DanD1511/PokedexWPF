using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Application.Contracts
{
    /// <summary>  
    /// Interface for the Pokemon repository.  
    /// Provides methods to retrieve Pokemon data.  
    /// </summary>  
    public interface IPokemonRepository
    {
        /// <summary>  
        /// Retrieves a Pokemon by its unique identifier.  
        /// </summary>  
        /// <param name="id">The unique identifier of the Pokemon.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the Pokemon entity.</returns>  
        Task<Pokemon> GetPokemonByID(int id);

        /// <summary>  
        /// Retrieves a list of all available Pokemons.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of Pokemon entities.</returns>  
        Task<List<Pokemon>> GetAllPokemons();
    }
}
