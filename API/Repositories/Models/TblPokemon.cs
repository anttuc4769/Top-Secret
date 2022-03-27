using System;
using System.Collections.Generic;

namespace API.Repositories.Models
{
    public partial class TblPokemon
    {
        public int RecordId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type1 { get; set; } = null!;
        public string? Type2 { get; set; }
        public int Total { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool Active { get; set; }
    }
}
