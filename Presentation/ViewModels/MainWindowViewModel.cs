using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokedexMVVM.Application.UseCases;
using PokedexMVVM.Domain.Entities;
using PokedexMVVM.Infrastructure.DataSource.APIs;
using PokedexMVVM.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace PokedexMVVM
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly GetPokemonByID? _getPokemonByID;
        private readonly PokemonRepository? _pokemonRepository;
        private readonly PokeAPI? _pokeAPI;

        [ObservableProperty]
        private int? _pokemonID;

        [ObservableProperty]
        private ObservableCollection<Pokemon> _pokemonList = new();

        public MainWindowViewModel()
        {
            _pokeAPI = new PokeAPI();
            _pokemonRepository = new PokemonRepository(_pokeAPI);
            _getPokemonByID = new GetPokemonByID(_pokemonRepository);
        }

        [RelayCommand]
        private async Task GetPokemonByID()
        {
            var pokemon = await _getPokemonByID?.GetPokemonByIDAsync(PokemonID ?? 1)!;
            PokemonList.Add(pokemon);
        }

        [RelayCommand]
        private async Task GetAllPokemons()
        {
            PokemonList.Clear();
            var pokemons = await _pokemonRepository?.GetAllPokemons()!;
            PokemonList = new ObservableCollection<Pokemon>(pokemons);
        }
    }
}
