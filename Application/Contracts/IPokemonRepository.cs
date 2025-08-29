using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Application.Contracts
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetPokemonByID(int id);
        Task<List<Pokemon>> GetAllPokemons();
    }
}
