using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TanachWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        [HttpGet]
        public List<Search> Get()
        {
            return BLL.searchFuncs.history();
        }

        [HttpDelete]
        public void Delete()
        {
            BLL.searchFuncs.deleteHistory();
        }
    }
}
