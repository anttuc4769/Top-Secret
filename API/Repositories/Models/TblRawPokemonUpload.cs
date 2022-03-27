using System;
using System.Collections.Generic;

namespace API.Repositories.Models
{
    public partial class TblRawPokemonUpload
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? PokemonId { get; set; }
        public string? PokemonName { get; set; }
        public string? PokemonType1 { get; set; }
        public string? PokemonType2 { get; set; }
        public string? PokemonTotal { get; set; }
        public string? PokemonHp { get; set; }
        public string? PokemonAttack { get; set; }
        public string? PokemonDefense { get; set; }
        public string? PokemonSpAttack { get; set; }
        public string? PokemonSpDefense { get; set; }
        public string? PokemonSpeed { get; set; }
        public string? Generation { get; set; }
        public string? Legendary { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
