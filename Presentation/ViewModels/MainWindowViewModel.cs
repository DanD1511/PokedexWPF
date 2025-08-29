using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokedexMVVM.Application.Services;
using PokedexMVVM.Domain.Entities;
using System.Collections.ObjectModel;

namespace PokedexMVVM
{
    /// <summary>  
    /// ViewModel for the MainWindow.  
    /// Handles the interaction between the UI and the application services.  
    /// </summary>  
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly GetPokemonService? _getPokemonService;

        /// <summary>  
        /// Gets or sets the ID of the Pokemon to retrieve.  
        /// </summary>  
        [ObservableProperty]
        private int? _pokemonID;

        /// <summary>  
        /// Gets or sets the collection of Pokemons displayed in the UI.  
        /// </summary>  
        [ObservableProperty]
        private ObservableCollection<Pokemon> _pokemonList = new();

        /// <summary>  
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.  
        /// </summary>  
        /// <param name="getPokemonService">The service used to retrieve Pokemon data.</param>  
        public MainWindowViewModel(GetPokemonService getPokemonService)
        {
            _getPokemonService = getPokemonService;
        }

        /// <summary>  
        /// Retrieves a Pokemon by its ID and adds it to the Pokemon list.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation.</returns>  
        [RelayCommand]
        private async Task GetPokemonByID()
        {
            var pokemon = await _getPokemonService?.GetPokemonByIDAsync(PokemonID ?? 1)!;
            PokemonList.Add(pokemon);
        }

        /// <summary>  
        /// Retrieves all available Pokemons and populates the Pokemon list.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation.</returns>  
        [RelayCommand]
        private async Task GetAllPokemons()
        {
            PokemonList.Clear();
            var pokemons = await _getPokemonService?.GetAllPokemonsAsync()!;
            PokemonList = new ObservableCollection<Pokemon>(pokemons);
        }
    }
}
