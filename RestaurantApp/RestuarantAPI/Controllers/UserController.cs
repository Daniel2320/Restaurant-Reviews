using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestaurantBL;
using RestaurantInfo;

namespace RestuarantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBL _operationsBL;

        public UserController(IBL _operationsBL)
        {
            this._operationsBL = _operationsBL;
        }
        /// <summary>
        /// Get all users in database
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
       public ActionResult<List<User>> GetUser()
       {
            Log.Information("User get user");
            var users = _operationsBL.GetUser();
           return Ok(users);

       }
        /// <summary>
        /// Search user by name users in database
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("name")]    
        public ActionResult<User> Get(string name)
        {
            Log.Information("User searched");
            var users = _operationsBL.SearchUser(name);
            if (users.Count <= 0)
                return NotFound($"Restaurant {name} is not in the database.");
            return Ok(users);
           
        }
        /// <summary>
        /// Add user to database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            Log.Information("User added");
            if (user == null)
                return BadRequest("Invalid User");
            _operationsBL.AddUser(user);
            return CreatedAtAction("Get", user);
        }
        /// <summary>
        /// Edit user by name
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromQuery, BindRequired] string name, [BindRequired] string password, [BindRequired] string email, [BindRequired] int userid )
        {
            User newUser = new()
            {
               Name = name,
               Password = password,
               Email = email,
               UserId = userid

            };
            Log.Information("User Changed");
            if (newUser.Name == null)
                newUser.Name = " ";
            try
            {
                _operationsBL.ChangeUser(newUser);
                return Created("GetAllRestaurants", newUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Delete user by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(string name)
        {

            try
            {
                Log.Information("User Deleted");
                if (_operationsBL.RemoveUser(name) == true)
                    return Ok($"User {name} Deleted!");
                else
                    return BadRequest($"User {name} does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
