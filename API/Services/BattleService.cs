using API.Enums;
using API.Models;
using API.Repositories;
using Hydra.Models;

namespace API.Services
{
    public interface IBattleService
    {
        PlayerBattleModel GetPlayerPokemon(int pokemonCount =  3);
    }

    public class BattleService : IBattleService
    {
        #region Properties
        
        private readonly IPokemonRepository _pokemonRepo;
        private readonly IPokemonService _pokemonService;
        private readonly IAuditor<AuditRow> _auditor;

        public BattleService(IPokemonRepository pokemonRepo, IAuditor<AuditRow> auditor, IPokemonService pokemonService)
        {
            _pokemonRepo = pokemonRepo;
            _auditor = auditor;
            _pokemonService = pokemonService;
        }

        #endregion

        public PlayerBattleModel GetPlayerPokemon(int pokemonCount = 3)
        {
            try
            {
                var playerBattleModel = new PlayerBattleModel();
                var c = 1;
                while (c <= pokemonCount)
                {
                    var pokemon = _pokemonRepo.GetRandomPokemon();
                    playerBattleModel.Pokemon.Add(new PokemonBattleModel(PokemonService.ConvertTableRecordToModel(pokemon)));
                    c++;
                }

                return playerBattleModel;
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.BattleService, AuditEnums.GetPlayerPokemon, AuditEnums.Error));
                throw;
            }
        }

        public void QuickBattle(BattleModel battle)
        {
            try
            {
                var player1 = battle.BattlePlayer.FirstOrDefault();
                var player2 = battle.BattlePlayer.LastOrDefault();

                var advantages = _pokemonRepo.GetTypeAdvantages();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.BattleService, AuditEnums.QuickBattle, AuditEnums.Error));
                throw;
            }
        }

        #region Private Methods



        #endregion
    }
}
