using CsvHelper;
using Hydra.Models;
using System.Globalization;

namespace API.Services
{
    public interface IProcessFileService
    {
        T Process<T>(string path);
    }

    public class ProcessPokemonFileService : IProcessFileService
    {
        private readonly List<string> _fileTypes = new List<string>() { ".csv" }; 

        public T Process<T>(string path)
        {
            try
            {
                //do validation on the path
                var extension = Path.GetExtension(path);
                if (!_fileTypes.Contains(extension))
                    throw new ArgumentException($"Invalid extension type of {extension}");

                var returnObj = new PokemonFileModel();
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<PokemonFileEntityModel>();
                if (records == null)
                {
                    returnObj.ErrorFlag = true;
                    returnObj.Msg = "Missing or Invalid data in file.";
                }
                else
                    returnObj.Records = records.ToList();

                return (T)Convert.ChangeType(returnObj, typeof(T));
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
