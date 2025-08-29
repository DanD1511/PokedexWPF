namespace PokedexMVVM.Domain.Entities
{
    public class Pokemon
    {
        public string? Name { get; set; }

        public override string ToString()
        {
            return Name ?? "Unknown Pokemon";
        }
    }
}
