using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Infrastructure.DataSource.Abstraction
{
    public interface IPokemonDataSource
    {
        Task<Pokemon> GetPokemonByID(int id);
        Task<List<Pokemon>> GetAllPokemons();
    }
}
