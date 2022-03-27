using Hydra.Enums;

namespace Hydra.Models
{
    public class PokemonListModel : BaseModel
    {
        public List<PokemonModel> Pokemons { get; set; }
    }

    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokemonType Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }
        public bool Active { get; set; }
    }
}
