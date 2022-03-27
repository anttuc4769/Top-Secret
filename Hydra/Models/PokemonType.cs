namespace Hydra.Models
{
    public class PokemonTypesModel : BaseModel
    {
        public List<PokemonTypeModel> PokemonTypes { get; set; }
    }

    public class PokemonTypeModel : EnumModel
    {
    }
}
