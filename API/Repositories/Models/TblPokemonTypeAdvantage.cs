using System;
using System.Collections.Generic;

namespace API.Repositories.Models
{
    public partial class TblPokemonTypeAdvantage
    {
        public string Attacking { get; set; } = null!;
        public byte Normal { get; set; }
        public double Fire { get; set; }
        public double Water { get; set; }
        public double Electric { get; set; }
        public double Grass { get; set; }
        public double Ice { get; set; }
        public double Fighting { get; set; }
        public double Poison { get; set; }
        public double Ground { get; set; }
        public double Flying { get; set; }
        public double Psychic { get; set; }
        public double Bug { get; set; }
        public double Rock { get; set; }
        public double Ghost { get; set; }
        public double Dragon { get; set; }
        public double Dark { get; set; }
        public double Steel { get; set; }
        public double Fairy { get; set; }
    }
}
