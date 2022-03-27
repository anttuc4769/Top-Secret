using API.Models;
using API.Repositories;
using API.Services;
using Moq;

namespace API_Tests.PokemonService
{
    public class BaseClass
    {
        protected IPokemonService PokemonService;
        protected Mock<IPokemonRepository> PokemonRepoMock;
        protected Mock<IAuditor<AuditRow>> AuditorMock;

        public void Setup()
        {
            PokemonRepoMock = new Mock<IPokemonRepository>();
            AuditorMock = new Mock<IAuditor<AuditRow>>();

            PokemonService = new API.Services.PokemonService(PokemonRepoMock.Object, AuditorMock.Object);
        }
    }
}
