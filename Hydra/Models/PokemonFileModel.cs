using Newtonsoft.Json;

namespace Hydra.Models
{
    public class PokemonFileModel : BaseModel
    {
        public List<PokemonFileEntityModel> Records { get; set; }
    }

    public class PokemonFileEntityModel
    {
        [JsonProperty("#")]
        [CsvHelper.Configuration.Attributes.Name("#")]
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("Type 1")]
        [CsvHelper.Configuration.Attributes.Name("Type 1")]
        public string Type1 { get; set; }
        [JsonProperty("Type 2")]
        [CsvHelper.Configuration.Attributes.Name("Type 2")]
        public string Type2 { get; set; }
        public string Total { get; set; }
        public string HP { get; set; }
        public string Attack { get; set; }
        public string Defense { get; set; }
        [JsonProperty("Sp. Atk")]
        [CsvHelper.Configuration.Attributes.Name("Sp. Atk")]
        public string SpAttack { get; set; }
        [JsonProperty("Sp. Def")]
        [CsvHelper.Configuration.Attributes.Name("Sp. Def")]
        public string SpDefense { get; set; }
        public string Speed { get; set; }
        public string Generation { get; set; }
        public string Legendary { get; set; }
    }
}
