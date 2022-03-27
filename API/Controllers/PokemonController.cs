using API.Enums;
using API.Models;
using API.Services;
using Hydra.Enums;
using Hydra.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        #region Properties

        private readonly IPokemonService _pokemonService;
        private readonly IAuditor<AuditRow> _auditor;

        public PokemonController(IPokemonService pokemonService, IAuditor<AuditRow> auditor)
        {
            _pokemonService = pokemonService;
            _auditor = auditor;
        }

        #endregion

        #region GET Methods

        [HttpGet]
        [Route("Search")]
        public PokemonListModel SearchPokemon([FromQuery]SearchType searchType, string? name, PokemonType? type1, PokemonType? type2, int? total, int? attack, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null, int? pageNumber = null, int? itemsPerPage = null)
        {
            try
            {
                PaginationModel? paginationModel = null;
                if (pageNumber != null && itemsPerPage != null)
                    paginationModel = new PaginationModel() { Page = pageNumber.Value, ItemsPerPage = itemsPerPage.Value };
                var searchResults = _pokemonService.SearchPokemon(searchType:searchType, pagination: paginationModel, name:name, type1:type1, type2:type2, total:total, attack:attack, defense:defense, spAttack:spAttack, spDefense:spDefense, speed:speed, generation:generation, legendary:legendary);
                return searchResults;
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { searchType, name, type1, type2, total, attack, defense, spDefense, spAttack, speed, generation, legendary, exception }, AuditEnums.PokemonController, AuditEnums.SearchPokemon, AuditEnums.Error));
                return new PokemonListModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }

        [HttpGet]
        [Route("Types")]
        public PokemonTypesModel Types()
        {
            try
            {
                return _pokemonService.PokemonTypes();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.PokemonController, AuditEnums.Types, AuditEnums.Error));
                return new PokemonTypesModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }

        #endregion
    }
}
