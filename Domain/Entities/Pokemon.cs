namespace PokedexMVVM.Domain.Entities
{
    /// <summary>  
    /// Represents a Pokemon entity with its properties and behaviors.  
    /// </summary>  
    public class Pokemon
    {
        /// <summary>  
        /// Gets or sets the name of the Pokemon.  
        /// </summary>  
        public string? Name { get; set; }

        /// <summary>  
        /// Returns a string representation of the Pokemon.  
        /// </summary>  
        /// <returns>The name of the Pokemon, or "Unknown Pokemon" if the name is null.</returns>  
        public override string ToString()
        {
            return Name ?? "Unknown Pokemon";
        }
    }
}
