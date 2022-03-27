using API.Repositories;
using API.Repositories.Models;
using Hydra.Enums;
using Hydra.Models;

namespace API.Services
{
    public interface IPokemonService
    {
        void UploadPokemon();
        PokemonListModel SearchPokemon(SearchType searchType = SearchType.Equal, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null);
    }

    public class PokemonService : IPokemonService
    {
        #region Properties
        
        private readonly IPokemonRepository _pokemonRepo;

        public PokemonService(IPokemonRepository pokemonRepo)
        {
            _pokemonRepo = pokemonRepo;
        }

        #endregion

        public void UploadPokemon()
        {
            try
            {
                var recordsToUpload = _pokemonRepo.GetDataFromRawTable();
                foreach (var record in recordsToUpload)
                {
                    var validate = ValidateRecord(record);
                    if (!validate)
                    {
                        //I would normally do some logging here. Maybe notify the user/uploader
                        continue;
                    }

                    var pokemon = ConvertRawTableRecordToModel(record);

                    if(pokemon.Legendary || pokemon.Type1 == PokemonType.Ghost || pokemon.Type2 == PokemonType.Ghost)
                        //Don't want to upload legendary or ghost pokemon
                        continue;

                    UpdatePokemonStats(pokemon);

                    var tableRecord = ModelToTableEntity(pokemon);
                    tableRecord.Active = true;

                    _pokemonRepo.InsertPokemon(tableRecord);
                }
            }
            catch (Exception exception)
            {

            }
        }

        public PokemonListModel SearchPokemon(SearchType searchType = SearchType.Equal, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null) 
        {
            try
            {
                var searchResults = _pokemonRepo.SearchPokemon(searchType, name, type1, type2, total, attack, defense, spAttack, spDefense, speed, generation, legendary);

                if (!searchResults.Any())
                    return new PokemonListModel() {Msg = "No Data"};

                var convertedResults = searchResults.Select(ConvertTableRecordToModel).ToList();

                return new PokemonListModel() { Pokemons = convertedResults };
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        #region Private Methods

        private bool ValidateRecord(TblRawPokemonUpload record)
        {
            try
            {

                if(string.IsNullOrEmpty(record.PokemonName))
                    return false;

                var isValid = true;

                isValid = ValidateInt(record.PokemonTotal);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonAttack);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonHp);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonDefense);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonSpAttack);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonSpDefense);
                if (!isValid)
                    return isValid;

                isValid = ValidateInt(record.PokemonDefense);

                return isValid;
            }
            catch (Exception)
            {
                //I don't want to throw here since if one fails we don't lose the rest. 
                return false;
            }
        }
        
        private static PokemonModel ConvertRawTableRecordToModel(TblRawPokemonUpload record)
        {
            try
            {
                var model = new PokemonModel();

                if (!string.IsNullOrEmpty(record.PokemonId))
                    model.Id = int.Parse(record.PokemonId);
                if (!string.IsNullOrEmpty(record.PokemonName))
                    model.Name = record.PokemonName;
                if (!string.IsNullOrEmpty(record.PokemonType1))
                {
                    Enum.TryParse(record.PokemonType1, true, out PokemonType type);
                    model.Type1 = type;
                }
                if (!string.IsNullOrEmpty(record.PokemonType2))
                {
                    Enum.TryParse(record.PokemonType2, true, out PokemonType type);
                    model.Type2 = type;
                }
                if (!string.IsNullOrEmpty(record.PokemonTotal))
                    model.Total = int.Parse(record.PokemonTotal);
                if (!string.IsNullOrEmpty(record.PokemonHp))
                    model.HP = int.Parse(record.PokemonHp);
                if (!string.IsNullOrEmpty(record.PokemonAttack))
                    model.Attack = int.Parse(record.PokemonAttack);
                if (!string.IsNullOrEmpty(record.PokemonDefense))
                    model.Defense = int.Parse(record.PokemonDefense);
                if (!string.IsNullOrEmpty(record.PokemonSpAttack))
                    model.SpAttack = int.Parse(record.PokemonSpAttack);
                if (!string.IsNullOrEmpty(record.PokemonSpDefense))
                    model.SpDefense = int.Parse(record.PokemonSpDefense);
                if (!string.IsNullOrEmpty(record.PokemonSpeed))
                    model.Speed = int.Parse(record.PokemonSpeed);
                if (!string.IsNullOrEmpty(record.Generation))
                    model.Generation = int.Parse(record.Generation);
                if (!string.IsNullOrEmpty(record.Legendary))
                    model.Legendary = bool.Parse(record.Legendary);

                return model;
            }
            catch (Exception)
            {
               //would normally log to logservice -> just have no time for this exercise
               throw;
            }
        }

        private static PokemonModel ConvertTableRecordToModel(TblPokemon record)
        {
            try
            {
                var model = new PokemonModel()
                {
                    Total = record.Total,
                    HP = record.Hp,
                    Attack = record.Attack,
                    Defense = record.Defense,
                    Speed = record.Speed,
                    SpAttack = record.SpAttack,
                    SpDefense = record.SpDefense,
                    Generation = record.Generation,
                    Legendary = record.Legendary,
                    Active = record.Active
                };

                if (record.Id != null)
                    model.Id = record.Id.Value;
                if (!string.IsNullOrEmpty(record.Name))
                    model.Name = record.Name;
                if (!string.IsNullOrEmpty(record.Type1))
                {
                    Enum.TryParse(record.Type1, true, out PokemonType type);
                    model.Type1 = type;
                }
                if (!string.IsNullOrEmpty(record.Type2))
                {
                    Enum.TryParse(record.Type2, true, out PokemonType type);
                    model.Type2 = type;
                }

                return model;
            }
            catch (Exception)
            {
                //would normally log to logservice -> just have no time for this exercise
                throw;
            }
        }


        private static TblPokemon ModelToTableEntity(PokemonModel model)
        {
            try
            {
                var tblEntity = new TblPokemon()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Type1 = model.Type1.ToString(),
                    Total = model.Total,
                    Hp = model.HP,
                    Attack = model.Attack,
                    Defense = model.Defense,
                    SpAttack = model.SpAttack,
                    SpDefense = model.SpDefense,
                    Speed = model.Speed,
                    Generation = model.Generation,
                    Legendary = model.Legendary,
                    Active = model.Active
                };

                if (model.Type2 != null)
                    tblEntity.Type2 = model.Type2.ToString();

                return tblEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual bool ValidateInt(string? value)
        {
            try
            {
                //Going to assume some values can be null 
                return string.IsNullOrEmpty(value) || int.TryParse(value, out _);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void UpdatePokemonStats(PokemonModel pokemon)
        {
            try
            {
                if (pokemon.Type1 == PokemonType.Steel || pokemon.Type2 == PokemonType.Steel)
                    UpdateSteelPokemon(pokemon);

                if (pokemon.Type1 == PokemonType.Fire || pokemon.Type2 == PokemonType.Fire)
                    UpdateFirePokemon(pokemon);

                if (pokemon.Type1 == PokemonType.Bug && pokemon.Type2 == PokemonType.Flying)
                    UpdateFlyingBugPokemon(pokemon);
                else if (pokemon.Type2 == PokemonType.Flying && pokemon.Type1 == PokemonType.Bug)
                    UpdateFlyingBugPokemon(pokemon);

                if (pokemon.Name.ToLower().StartsWith("g"))
                    UpdatePokemonThatStartWithG(pokemon);
            }
            catch (Exception)
            {

            }
        }

        private static void UpdateSteelPokemon(PokemonModel entity)
        {
            try
            {
                entity.HP *= 2;
            }
            catch (Exception)
            {
                //would normally log to logservice -> just have no time for this exercise
            }
        }

        private static void UpdateFirePokemon(PokemonModel pokemon)
        {
            try
            {
                const int percent = 10;
                var value = pokemon.Attack / percent;
                pokemon.Attack -= value;
            }
            catch (Exception)
            {
                //would normally log to logservice -> just have no time for this exercise
            }
        }

        private static void UpdateFlyingBugPokemon(PokemonModel pokemon)
        {
            try
            {
                const int percent = 10;
                var value = pokemon.Speed / percent;
                pokemon.Speed += value;
            }
            catch (Exception)
            {
                //would normally log to logservice -> just have no time for this exercise
            }
        }

        private static void UpdatePokemonThatStartWithG(PokemonModel pokemon)
        {
            try
            {
                var value = pokemon.Name.ToLower().Count(a => a != 'g') * 5;
                pokemon.Defense += value;
            }
            catch (Exception)
            {
                //would normally log to logservice -> just have no time for this exercise
            }
        }

        #endregion
    }
}
