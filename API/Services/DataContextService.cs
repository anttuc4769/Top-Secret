using API.Repositories.Models;

namespace API.Services
{
    public interface IDataContextService
    {
        PokemanContext GetDataContext();
        IConfiguration GetConfiguration();
    }
    public class DataContextService : IDataContextService
    {
        #region Properties

        private readonly PokemanContext _dbContext;
        private readonly IConfiguration _configuration;

        public DataContextService(PokemanContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        #endregion

        public PokemanContext GetDataContext()
        {
            return _dbContext;
        }

        public IConfiguration GetConfiguration()
        {
            return _configuration;
        }
    }
}
