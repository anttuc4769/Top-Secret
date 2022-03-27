using API.Enums;
using API.Models;
using API.Services;
using Hydra.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        #region Properties

        private readonly IBattleService _battleService;
        private readonly IAuditor<AuditRow> _auditor;

        public BattleController(IBattleService battleService, IAuditor<AuditRow> auditor)
        {
            _battleService = battleService;
            _auditor = auditor;
        }

        #endregion

        #region GET Methods

        [HttpGet]
        [Route("Player/Pokemon")]
        public PlayerBattleModel GetPlayerPokemon()
        {
            try
            {
                return _battleService.GetPlayerPokemon();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.BattleController, AuditEnums.GetPlayerPokemon, AuditEnums.Error));
                return new PlayerBattleModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }

        #endregion

        #region POST Methods

        [HttpPost]
        [Route("Start")]
        public BattleModel StartBattle()
        {
            try
            {
                var battleModel = new BattleModel();
                battleModel.BattlePlayer.Add(_battleService.GetPlayerPokemon());
                var cp = _battleService.GetPlayerPokemon();
                cp.Player = new PlayerModel() { Name = "Computer" };
                battleModel.BattlePlayer.Add(cp);
                return battleModel;
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.BattleController, AuditEnums.StartBattle, AuditEnums.Error));
                return new BattleModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }


        #endregion
    }
}
