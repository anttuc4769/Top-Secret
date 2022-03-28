using Hydra.Enums;
using Xunit;

namespace API_Tests.PokemonService
{
    public class PokemonSearch : BaseClass
    {
        public PokemonSearch()
        {
            Setup();
        }

        [Fact]
        public void SearchEqual()
        {
            var found = PokemonService.SearchPokemon(name: "Test1");
            Assert.True(found != null && found.Pokemons.Count == 1);
        }

        [Fact]
        public void SearchEqualNotInDb()
        {
            var found = PokemonService.SearchPokemon(name: "Test991");
            Assert.True(found.Pokemons == null);
        }

        [Fact]
        public void SearchLike()
        {
            var found = PokemonService.SearchPokemon( searchType: SearchType.Like, name: "Test");
            Assert.True(found != null && found.Pokemons.Count == 3);
        }


        [Fact]
        public void SearchNotEqual()
        {
            var found = PokemonService.SearchPokemon(searchType: SearchType.NotEqual, name: "Test2");
            Assert.True(found != null && found.Pokemons.Count == 2);
        }
    }
}
