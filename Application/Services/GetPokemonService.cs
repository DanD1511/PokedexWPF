using PokedexMVVM.Application.UseCases;

namespace PokedexMVVM.Application.Services
{
    /// <summary>  
    /// Service class for retrieving Pokemon data.  
    /// Provides methods to fetch Pokemon by ID or retrieve all Pokemons.  
    /// </summary>  
    public class GetPokemonService
    {
        private readonly GetPokemonByID? _getPokemonByID;
        private readonly GetAllPokemons? _getAllPokemons;

        /// <summary>  
        /// Initializes a new instance of the <see cref="GetPokemonService"/> class.  
        /// </summary>  
        /// <param name="getPokemonByID">Use case for retrieving a Pokemon by ID.</param>  
        /// <param name="getAllPokemons">Use case for retrieving all Pokemons.</param>  
        public GetPokemonService(GetPokemonByID getPokemonByID, GetAllPokemons getAllPokemons)
        {
            _getPokemonByID = getPokemonByID;
            _getAllPokemons = getAllPokemons;
        }

        /// <summary>  
        /// Retrieves a list of all available Pokemons asynchronously.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of Pokemon entities.</returns>  
        public async Task<List<Domain.Entities.Pokemon>> GetAllPokemonsAsync()
        {
            return await _getAllPokemons?.GetAllPokemonsAsync()!;
        }

        /// <summary>  
        /// Retrieves a Pokemon by its unique identifier asynchronously.  
        /// </summary>  
        /// <param name="id">The unique identifier of the Pokemon.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the Pokemon entity.</returns>  
        public async Task<Domain.Entities.Pokemon> GetPokemonByIDAsync(int id)
        {
            return await _getPokemonByID?.GetPokemonByIDAsync(id)!;
        }
    }
}
