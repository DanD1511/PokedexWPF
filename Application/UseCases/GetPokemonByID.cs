using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Domain.Entities;

namespace PokedexMVVM.Application.UseCases
{
    public class GetPokemonByID
    {
        private readonly IPokemonRepository? _pokemonRepository;

        public GetPokemonByID(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

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
