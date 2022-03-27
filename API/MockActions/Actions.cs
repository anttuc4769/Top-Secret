using API.Services;
using Hydra.Models;

namespace API.MockActions
{
    public interface IActions
    {
        BaseModel UploadFile();
        BaseModel ProcessUpload();
    }

    //Since I'm getting close to time. I'm creating this class to mock actions of users that I normally would keep dynamic 
    public class Actions : IActions
    {
        #region Properties

        private readonly IProcessFileService _processFileService;
        private readonly IUploadFileService _uploadFileService;
        private readonly IPokemonService _pokemonService;

        public Actions(IProcessFileService processFileService, IUploadFileService uploadFileService, IPokemonService pokemonService)
        {
            _processFileService = processFileService;
            _uploadFileService = uploadFileService;
            _pokemonService = pokemonService;
        }

        #endregion

        public BaseModel UploadFile()
        {
            try
            {
                //Normally this would be some type of input for on the UI 
                //TODO: I know this is NOT a good way to get the path. If I have time, I will come back and do it better. 
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var path = $"{baseDirectory.Split("bin").First()}data\\pokemon.csv";
                var parsedObj = _processFileService.Process<PokemonFileModel>(path);
                var insertIntoDbResults = _uploadFileService.UploadFile(parsedObj);
                return new BaseModel(){ ErrorFlag = !insertIntoDbResults };
            }
            catch (Exception exception)
            {
                return new BaseModel(){ Msg = exception.Message, ErrorFlag = true};
            }
        }

        public BaseModel ProcessUpload()
        {
            try
            {
                _pokemonService.UploadPokemon();
                return new BaseModel(){ ErrorFlag = true };
            }
            catch (Exception exception)
            {
                return new BaseModel() { Msg = exception.Message, ErrorFlag = true };
            }
        }
    }
}
