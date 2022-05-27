using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBL;
using RestaurantInfo;

namespace RestuarantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AverageController : ControllerBase
    {
        private IBL _operationsBL;

        public AverageController(IBL _operationsBL)
        {
            this._operationsBL = _operationsBL;
        }
        /// <summary>
        /// Gets averaged of each restaurant that has a current rating.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AverageRating>> Get()
        {
            Log.Information("Get Average Rating");
            var average = _operationsBL.GetAverageRating();
            return Ok(average);
        }
    }
}
