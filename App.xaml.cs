using Microsoft.Extensions.DependencyInjection;
using PokedexMVVM.Application.Contracts;
using PokedexMVVM.Application.Services;
using PokedexMVVM.Application.UseCases;
using PokedexMVVM.Infrastructure.DataSource.Abstraction;
using PokedexMVVM.Infrastructure.DataSource.APIs;
using PokedexMVVM.Infrastructure.Repositories;
using System.Windows;

namespace PokedexMVVM
{
    /// <summary>  
    /// Interaction logic for App.xaml  
    /// </summary>  
    public partial class App : System.Windows.Application
    {
        /// <summary>  
        /// Gets the service provider for dependency injection.  
        /// </summary>  
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>  
        /// Handles the application startup event.  
        /// Configures services and displays the main window.  
        /// </summary>  
        /// <param name="e">Event arguments for the startup event.</param>  
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        /// <summary>  
        /// Configures the services for dependency injection.  
        /// Registers services for the presentation, application, and infrastructure layers.  
        /// </summary>  
        /// <param name="services">The service collection to configure.</param>  
        private void ConfigureServices(ServiceCollection services)
        {
            // Presentation layer  
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();

            // Application layer  
            services.AddTransient<GetPokemonByID>();
            services.AddTransient<GetAllPokemons>();
            services.AddTransient<GetPokemonService>();

            // Infrastructure layer  
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddHttpClient<IPokemonDataSource, PokeAPI>(c =>
            {
                c.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });
        }
    }
}
