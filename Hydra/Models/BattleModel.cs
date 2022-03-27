namespace Hydra.Models
{
    public class BattleModel : BaseModel
    {
        public List<PlayerBattleModel> BattlePlayer { get; set; } = new List<PlayerBattleModel>();
        public List<BattleMove> PreviousMoves { get; set; }
    }

    public class PlayerBattleModel : BaseModel
    {
        public List<PokemonBattleModel> Pokemon { get; set; } = new List<PokemonBattleModel>();
        public PlayerModel Player { get; set; }
        public BattleMove LastMove { get; set; }
        public List<BattleMove> PreviousMoves { get; set; }
    }

    public class BattleMove
    {
        public int ActivePokemonId { get; set; }
        public BattleMove Move { get; set; }
    }

    public class PokemonBattleModel : PokemonModel
    {
        public PokemonBattleModel(PokemonModel pokemonModel)
        {
            Id = pokemonModel.Id;
            Name = pokemonModel.Name;
            Type1 = pokemonModel.Type1;
            Type2 = pokemonModel.Type2;
            Total = pokemonModel.Total;
            HP = pokemonModel.HP;
            Attack = pokemonModel.Attack;
            Defense = pokemonModel.Defense;
            SpAttack = pokemonModel.SpAttack;
            SpDefense = pokemonModel.SpDefense;
            Speed = pokemonModel.Speed;
            Generation = pokemonModel.Generation;
            Legendary = pokemonModel.Legendary;
            Active = pokemonModel.Active;
        }

        public int HpRemaining { get; set; }
        public int HpLost { get; set; }
        public int HpLostTurn { get; set; }
        public bool Fainted { get; set; }
    }
}
