using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantInfo;
using RestaurantBL;
using Microsoft.Extensions.Caching.Memory;
using RestuarantAPI.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RestuarantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private IBL _operationsBL;
        private IMemoryCache memoryCache;
        public RestaurantController(IBL _operationsBL, IMemoryCache memoryCache)
        {
            this._operationsBL = _operationsBL;
            this.memoryCache = memoryCache;
        }
        /// <summary>
        /// Get Method, Gets all restuarants in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Restaurant>> Get()
        {
            Log.Information("Restaurant get all");
            var restaurants = _operationsBL.GetAllRestaurants();
            return Ok(restaurants);
        }
        /// <summary>
        /// Search Restaurant by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        public ActionResult<Restaurant> Get(string name)
        {
            Log.Information("Restaurant searched by name");
            var rest = _operationsBL.SearcheRstaurants(name);
            if (rest.Count <= 0)
                return NotFound($"Restaurant {name} is not in the database.");
            return Ok(rest);
        }
        /// <summary>
        /// Adds a Restaurant to the database
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody] Restaurant restaurant)
        {
            Log.Information("Restaurant added");
            if (restaurant == null)
                return BadRequest("Invalid Resturant");
            _operationsBL.AddRestaurant(restaurant);
            return CreatedAtAction("Get", restaurant);
        }
        /// <summary>
        /// Should edit restaurant by name.
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut]
        public ActionResult Put([FromQuery, BindRequired] int restid, [BindRequired] string name, [BindRequired] string state,[BindRequired] string address, [BindRequired] string city, [BindRequired] string zipcode)
        {
            Restaurant newRestaurant = new()
            {
                RestId = restid,
                Name = name,
                State = state,
                Address = address,
                City = city,
                ZipCode = zipcode

            };
            Log.Information("Restaurant changed");
            if (newRestaurant.Name == null)
                newRestaurant.Name = " ";
            try
            {
                _operationsBL.ChangeRestaurant(newRestaurant);
                return Created("GetAllRestaurants", newRestaurant);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Should delete restaurant by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete]
        public ActionResult Delete([FromQuery, BindRequired]string name)
        {

            Log.Information("Restaurant deleted");
            try
            {
               
                if (_operationsBL.RemoveRestaurant(name) == true)
                    return Ok($"Restaurant {name} Deleted!");
                else
                    return BadRequest($"Restaurant {name} does not exist");
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
 
           
        }
       
    }
}
