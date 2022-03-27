using API.Enums;
using API.Models;
using API.Repositories.Models;
using API.Services;
using Hydra.Enums;
using Hydra.Models;

namespace API.Repositories
{
    public interface IPokemonRepository
    {
        List<TblRawPokemonUpload> GetDataFromRawTable();
        void InsertPokemon(TblPokemon record);
        List<TblPokemon> SearchPokemon(SearchType searchType, PaginationModel? pagination = null, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null);
    }

    public class PokemonRepository : IPokemonRepository
    {
        #region Properties

        private readonly IDataContextService _dataContextService;
        private readonly IAuditor<AuditRow> _auditor;

        public PokemonRepository(IDataContextService dataContextService, IAuditor<AuditRow> auditor)
        {
            _dataContextService = dataContextService;
            _auditor = auditor;
        }

        #endregion

        public List<TblRawPokemonUpload> GetDataFromRawTable()
        {
            try
            {
                var records = _dataContextService.GetDataContext().TblRawPokemonUploads.ToList();
                return records;
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.PokemonRepository, AuditEnums.GetDataFromRawTable, AuditEnums.Error));
                throw;
            }
        }

        public void InsertPokemon(TblPokemon record)
        {
            try
            {
                _dataContextService.GetDataContext().TblPokemons.Add(record);
                _dataContextService.GetDataContext().SaveChanges();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { exception }, AuditEnums.PokemonRepository, AuditEnums.InsertPokemon, AuditEnums.Error));
                throw;
            }
        }

        public List<TblPokemon> SearchPokemon(
            SearchType searchType,
            PaginationModel? pagination = null,
            string? name = null, 
            PokemonType? type1 = null, 
            PokemonType? type2 = null, 
            int? total = null, 
            int? attack = null, 
            int? defense = null, 
            int? spAttack = null, 
            int? spDefense = null, 
            int? speed = null, 
            int? generation = null, 
            bool? legendary = null)
        {
            try
            {
                return searchType switch
                {
                    SearchType.Equal => QueryPokemonsEqual(pagination, name, type1, type2, total, attack, defense, spAttack,
                        spDefense, speed, generation, legendary),
                    SearchType.NotEqual => QueryPokemonsNotEqual(pagination, name, type1, type2, total, attack, defense, spAttack, spDefense, speed, generation, legendary),
                    SearchType.Like => QueryPokemonsLike(pagination, name, type1, type2, total, attack, defense, spAttack,
                        spDefense, speed, generation, legendary),
                    _ => throw new Exception("Invalid Search Type.")
                };
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { searchType, pagination, name, type1, type2, total, attack, defense, spDefense, spAttack, speed, generation, legendary, exception }, AuditEnums.PokemonRepository, AuditEnums.SearchPokemon, AuditEnums.Error));
                throw;
            }
        }

        #region Private Methods

        private List<TblPokemon> QueryPokemonsEqual(PaginationModel? pagination = null, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null)
        {
            try
            {
                var queryable = _dataContextService.GetDataContext().TblPokemons.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                    queryable = queryable.Where(a => a.Name == name).AsQueryable();
                if (type1 != null)
                    queryable = queryable.Where(a => a.Type1 == type1.ToString()).AsQueryable();
                if (type2 != null)
                    queryable = queryable.Where(a => a.Type2 == type2.ToString()).AsQueryable();
                if (total != null)
                    queryable = queryable.Where(a => a.Total == total).AsQueryable();
                if (attack != null)
                    queryable = queryable.Where(a => a.Attack == attack).AsQueryable();
                if (defense != null)
                    queryable = queryable.Where(a => a.Defense == defense).AsQueryable();
                if (spAttack != null)
                    queryable = queryable.Where(a => a.SpAttack == spAttack).AsQueryable();
                if (spDefense != null)
                    queryable = queryable.Where(a => a.SpDefense == spDefense).AsQueryable();
                if (speed != null)
                    queryable = queryable.Where(a => a.Speed == speed).AsQueryable();
                if (generation != null)
                    queryable = queryable.Where(a => a.Generation == generation).AsQueryable();
                if (legendary != null)
                    queryable = queryable.Where(a => a.Legendary == legendary).AsQueryable();

                if(pagination == null)
                    return queryable.ToList();

                return queryable.Skip(pagination.Skip).Take(pagination.ItemsPerPage).ToList();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { pagination, name, type1, type2, total, attack, defense, spDefense, spAttack, speed, generation, legendary, exception }, AuditEnums.PokemonRepository, AuditEnums.Private, AuditEnums.QueryPokemonsEqual, AuditEnums.Error));
                throw;
            }
        }

        private List<TblPokemon> QueryPokemonsNotEqual(PaginationModel? pagination = null, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null)
        {
            try
            {
                var queryable = _dataContextService.GetDataContext().TblPokemons.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                    queryable = queryable.Where(a => a.Name != name).AsQueryable();
                if (type1 != null)
                    queryable = queryable.Where(a => a.Type1 != type1.ToString()).AsQueryable();
                if (type2 != null)
                    queryable = queryable.Where(a => a.Type2 != type2.ToString()).AsQueryable();
                if (total != null)
                    queryable = queryable.Where(a => a.Total != total).AsQueryable();
                if (attack != null)
                    queryable = queryable.Where(a => a.Attack != attack).AsQueryable();
                if (defense != null)
                    queryable = queryable.Where(a => a.Defense != defense).AsQueryable();
                if (spAttack != null)
                    queryable = queryable.Where(a => a.SpAttack != spAttack).AsQueryable();
                if (spDefense != null)
                    queryable = queryable.Where(a => a.SpDefense != spDefense).AsQueryable();
                if (speed != null)
                    queryable = queryable.Where(a => a.Speed != speed).AsQueryable();
                if (generation != null)
                    queryable = queryable.Where(a => a.Generation != generation).AsQueryable();
                if (legendary != null)
                    queryable = queryable.Where(a => a.Legendary != legendary).AsQueryable();

                if (pagination == null)
                    return queryable.ToList();

                return queryable.Skip(pagination.Skip).Take(pagination.ItemsPerPage).ToList();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { pagination, name, type1, type2, total, attack, defense, spDefense, spAttack, speed, generation, legendary, exception }, AuditEnums.PokemonRepository, AuditEnums.Private, AuditEnums.QueryPokemonsNotEqual, AuditEnums.Error));
                throw;
            }
        }

        private List<TblPokemon> QueryPokemonsLike(PaginationModel? pagination = null, string? name = null, PokemonType? type1 = null, PokemonType? type2 = null, int? total = null, int? attack = null, int? defense = null, int? spAttack = null, int? spDefense = null, int? speed = null, int? generation = null, bool? legendary = null)
        {
            try
            {
                var queryable = _dataContextService.GetDataContext().TblPokemons.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                    queryable = queryable.Where(a => a.Name.Contains(name)).AsQueryable();
                if (type1 != null)
                    queryable = queryable.Where(a => a.Type1.Contains(type1.ToString())).AsQueryable();
                if (type2 != null)
                    queryable = queryable.Where(a => a.Type2 != null && a.Type2.Contains(type2.ToString())).AsQueryable();
                if (total != null)
                    queryable = queryable.Where(a => a.Total.ToString().Contains(total.ToString())).AsQueryable();
                if (attack != null)
                    queryable = queryable.Where(a => a.Attack.ToString().Contains(attack.ToString())).AsQueryable();
                if (defense != null)
                    queryable = queryable.Where(a => a.Defense.ToString().Contains(defense.ToString())).AsQueryable();
                if (spAttack != null)
                    queryable = queryable.Where(a => a.SpAttack.ToString().Contains(spAttack.ToString())).AsQueryable();
                if (spDefense != null)
                    queryable = queryable.Where(a => a.SpDefense.ToString().Contains(spDefense.ToString())).AsQueryable();
                if (speed != null)
                    queryable = queryable.Where(a => a.Speed.ToString().Contains(speed.ToString())).AsQueryable();
                if (generation != null)
                    queryable = queryable.Where(a => a.Generation.ToString().Contains(generation.ToString())).AsQueryable();
                if (legendary != null)
                    queryable = queryable.Where(a => a.Legendary != legendary).AsQueryable();

                if (pagination == null)
                    return queryable.ToList();

                return queryable.Skip(pagination.Skip).Take(pagination.ItemsPerPage).ToList();
            }
            catch (Exception exception)
            {
                _auditor.Audit(new AuditBuilder(new { pagination, name, type1, type2, total, attack, defense, spDefense, spAttack, speed, generation, legendary, exception }, AuditEnums.PokemonRepository, AuditEnums.Private, AuditEnums.QueryPokemonsLike, AuditEnums.Error));
                throw;
            }
        }

        #endregion
    }
}
