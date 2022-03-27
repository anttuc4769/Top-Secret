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

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        #endregion

        #region GET Methods

        [HttpGet]
        [Route("Search")]
        public PokemonListModel SearchPokemon([FromQuery]string name)
        {
            try
            {
                var searchResults = _pokemonService.SearchPokemon(name: name);
                return searchResults;
            }
            catch (Exception exception)
            {
                return new PokemonListModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }

        [HttpGet]
        [Route("Types")]
        public PokemonTypesModel Types()
        {
            try
            {
                var types = Enum.GetValues(typeof(PokemonType)).Cast<PokemonType>().Select(d => new PokemonTypeModel() { Text = d.ToString(), Value = (int)d }).ToList();

                return new PokemonTypesModel(){ PokemonTypes = types };
            }
            catch (Exception exception)
            {
                return new PokemonTypesModel() { ErrorFlag = true, Msg = exception.Message };
            }
        }

        #endregion
    }
}
