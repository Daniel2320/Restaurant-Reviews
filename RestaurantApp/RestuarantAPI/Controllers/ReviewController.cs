using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantInfo;
using RestuarantAPI.Repository;

namespace RestuarantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private IBL _operationsBL;
        
        public ReviewController(IBL _operationsBL)
        {
            this._operationsBL = _operationsBL;
        }
        /// <summary>
        /// Gets all the reviews from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Review>> GetReview()
        {
            Log.Information("Review seached");
            var reviews = _operationsBL.GetAllReviews();
            return Ok(reviews);
        }
        /// <summary>
        /// Adds review to database
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Review review)
        {
            Log.Information("Review added");
            if (review == null)
                return BadRequest("Invalid Review");
            _operationsBL.AddReview(review);
            return CreatedAtAction("Post", review);
        }
        /// <summary>
        /// Should edit review by id
        /// </summary>
        /// <param name="review"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromQuery, BindRequired] int reviewid, [BindRequired] string note, [BindRequired] int rating, int restid)
        {
            Log.Information("Review changed");
            Review newReview = new()
            {
                RestId = restid,
                Note = note,
                Rating = rating,
                ReviewId = reviewid
            };
            if (newReview.Note == null)
                newReview.Note = " ";
            try
            {
                _operationsBL.ChangeReview(newReview);
                return Created("GetAllReviews", newReview);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Should delete by id
        /// </summary>
        /// <param name="reviewid"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int reviewid, int restid)
        {

            Log.Information("Review deleted");
            try
            {
                if (_operationsBL.RemoveReview(reviewid,restid) == true)
                    return Ok($"Restaurant review Deleted!");
                else
                    return BadRequest($"Restaurant review does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
