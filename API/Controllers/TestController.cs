using API.MockActions;
using Hydra.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Properites
        
        private readonly IActions _actions;

        public TestController(IActions actions)
        {
            _actions = actions;
        }

        #endregion

        #region GET Methods

        /// <summary>
        /// Mimic users actions that would normally be UI inputs.
        /// </summary>
        /// <returns>Boolean is Successful</returns>
        [HttpGet, Route("MimicUser/Run/All")]
        public BaseModel MimicUserActions()
        {
            try
            {
                var results = _actions.UploadFile();
                if (results.ErrorFlag)
                    return results;
                results = _actions.ProcessUpload();
                return results;
            }
            catch (Exception exception)
            {
                return new BaseModel() { Msg = exception.Message, ErrorFlag = true };
            }
        }
        #endregion
    }
}
