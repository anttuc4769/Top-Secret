using API.Models;
using API.Repositories;
using API.Repositories.Models;
using API.Services;
using Hydra.Enums;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Tests.PokemonService
{
    public class BaseClass
    {
        protected Mock<IAuditor<AuditRow>> AuditorMock;
        protected Mock<PokemanContext> DatabaseMock;
        protected IPokemonService PokemonService;
        protected IPokemonRepository PokemonRepoMock;
        protected IDataContextService DataContextMock;
        private readonly List<TblPokemon> _pokemonRecords = new()
        {
            new TblPokemon(){
                Id = 1,
                Name = "Test1",
                Type1 = PokemonType.Bug.ToString(),
                Type2 = PokemonType.Dark.ToString(),
                Hp = 100,
                Attack = 90,
                SpAttack = 10,
                SpDefense = 20,
                Speed = 100,
                Defense = 90,
                Generation = 1,
                Total = 900,
                Legendary = true,
                Created = DateTimeOffset.Now,
                Active = true
            },
            new TblPokemon()
            {
                Id = 2,
                Name = "Test2",
                Type1 = PokemonType.Dragon.ToString(),
                Type2 = PokemonType.Fire.ToString(),
                Hp = 100,
                Attack = 90,
                SpAttack = 10,
                SpDefense = 20,
                Speed = 100,
                Defense = 90,
                Generation = 1,
                Total = 900,
                Legendary = true,
                Created = DateTimeOffset.Now,
                Active = true
            },
            new TblPokemon()
            {
                Id = 3,
                Name = "Test3",
                Type1 = PokemonType.Ice.ToString(),
                Hp = 100,
                Attack = 90,
                SpAttack = 10,
                SpDefense = 20,
                Speed = 100,
                Defense = 90,
                Generation = 1,
                Total = 900,
                Legendary = true,
                Created = DateTimeOffset.Now,
                Active = true
            }
        };

        public void Setup()
        {
            AuditorMock = new Mock<IAuditor<AuditRow>>();
            DatabaseMock = new Mock<PokemanContext>();
            DatabaseMock.Setup(x => x.TblPokemons.AsQueryable()).Returns(_pokemonRecords.AsQueryable);
            DataContextMock = new DataContextService(DatabaseMock.Object, new ConfigurationManager());
            PokemonRepoMock = new PokemonRepository(DataContextMock, AuditorMock.Object);

            PokemonService = new API.Services.PokemonService(PokemonRepoMock, AuditorMock.Object);
        }
    }
}
