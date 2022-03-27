using API.Repositories.Models;
using Hydra.Models;

namespace API.Services
{
    public interface IUploadFileService
    {
        bool UploadFile<T>(T obj);
    }

    public class UploadPokemonFileService : IUploadFileService
    {
        #region Properties

        private readonly IDataContextService _dataContextService;
        private const string FileName = "Pokemon File";

        public UploadPokemonFileService(IDataContextService dataContextService)
        {
            _dataContextService = dataContextService;
        }

        #endregion


        public bool UploadFile<T>(T obj)
        {
            try
            {
                if(obj == null)
                    throw new Exception("Missing data.");
                var convertedObj = obj as PokemonFileModel;
                if (convertedObj == null)
                    throw new Exception("Conversion failed.");
                var created = DateTime.Now;

                foreach (var record in convertedObj.Records)
                {
                    var newRecord = new TblRawPokemonUpload()
                    {
                        FileName = $"{FileName}_{created:g}",   
                        PokemonId = record.Id,
                        PokemonName = record.Name,
                        PokemonType1 = record.Type1,
                        PokemonType2 = record.Type2,
                        PokemonTotal = record.Total,
                        PokemonHp = record.HP,
                        PokemonAttack = record.Attack,
                        PokemonDefense = record.Defense,
                        PokemonSpAttack = record.SpAttack,
                        PokemonSpDefense = record.SpDefense,   
                        PokemonSpeed = record.Speed,
                        Generation = record.Generation,
                        Legendary = record.Legendary,
                        Created = created
                    };
                    _dataContextService.GetDataContext().TblRawPokemonUploads.Add(newRecord);
                    _dataContextService.GetDataContext().SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
