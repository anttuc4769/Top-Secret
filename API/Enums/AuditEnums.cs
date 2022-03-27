using System.ComponentModel;

namespace API.Enums
{
    public enum AuditEnums
    {
        View,
        Api,
        Private,

        #region Statuses

        [Description("Status")]
        Error,
        [Description("Status")]
        Success,
        [Description("Status")]
        Warning,
        [Description("Status")]
        Critical,
        [Description("Status")]
        Security,

        #endregion

        #region Class/Controllers

        PokemonService, 
        PokemonController,
        PokemonRepository,
        BattleController,
        BattleService,

        #endregion

        #region Methods

        UploadPokemon,
        PokemonTypes,
        SearchPokemon,
        Types,
        QueryPokemonsLike,
        QueryPokemonsNotEqual,
        QueryPokemonsEqual,
        InsertPokemon,
        GetDataFromRawTable,
        GetTypeAdvantages,
        QueryPokemon,
        GetPokemon,
        GetRandomPokemon,
        GetPlayerPokemon,
        StartBattle,
        QuickBattle,
        Battle

        #endregion
    }
}
