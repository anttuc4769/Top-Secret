using API.Repositories;
using API.Services;
using Moq;

namespace API_Tests.PokemonService
{
    public class BaseClass
    {
        protected IPokemonService PokemonService;
        protected Mock<IPokemonRepository> PokemonRepoMock;

        public void Setup()
        {
            PokemonRepoMock = new Mock<IPokemonRepository>();

            PokemonService = new API.Services.PokemonService(PokemonRepoMock.Object);
        }
    }
}
