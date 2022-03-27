using System.Linq;
using Xunit;

namespace API_Tests.PokemonService
{
    public class PokemonTypes : BaseClass
    {
        public PokemonTypes()
        {
            Setup();
        }

        [Fact]
        public void CheckCountOfTypes()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Count == 18);
        }

        [Fact]
        public void CheckForBugType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Bug"));
        }

        [Fact]
        public void CheckForDarkType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Dark"));
        }

        [Fact]
        public void CheckForDragonType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Dragon"));
        }

        [Fact]
        public void CheckForElectricType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Electric"));
        }

        [Fact]
        public void CheckForFairyType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Fairy"));
        }

        [Fact]
        public void CheckForFightingType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Fighting"));
        }

        [Fact]
        public void CheckForFireType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Fire"));
        }

        [Fact]
        public void CheckForFlyingType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Flying"));
        }

        [Fact]
        public void CheckForGhostType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Ghost"));
        }

        [Fact]
        public void CheckForGrassType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Grass"));
        }

        [Fact]
        public void CheckForGroundType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Ground"));
        }

        [Fact]
        public void CheckForIceType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Ice"));
        }

        [Fact]
        public void CheckForNormalType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Normal"));
        }

        [Fact]
        public void CheckForPoisonType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Poison"));
        }

        [Fact]
        public void CheckForPsychicType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Psychic"));
        }

        [Fact]
        public void CheckForRockType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Rock"));
        }

        [Fact]
        public void CheckForSteelType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Steel"));
        }

        [Fact]
        public void CheckForWaterType()
        {
            var types = PokemonService.PokemonTypes();
            Assert.True(types != null && types.PokemonTypes.Any(a => a.Text == "Water"));
        }
    }
}
