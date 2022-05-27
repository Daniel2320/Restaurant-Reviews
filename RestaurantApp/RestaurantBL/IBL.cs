using RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBL
{
    public interface IBL:IRestaurantSearch
    {
        
        List<User> SearchUser(string name);
        List<Restaurant> GetAllRestaurants();
        List<Review> GetAllReviews();
        List<AverageRating> GetAverageRating();
        List<User> GetUser();
        Restaurant AddRestaurant(Restaurant restaurant);
        Review AddReview(Review review);
        User AddUser(User user);
        List<Restaurant> SearcheRstaurants(string name);
        bool RemoveRestaurant(string restaurantName);
        bool RemoveUser(string user);
        bool RemoveReview(int reviewId, int restId);
        Restaurant ChangeRestaurant(Restaurant newRestaurant);
        Review ChangeReview(Review newReview);
        User ChangeUser(User newUser);
    }
    public interface IRestaurantSearch
    {
        List<Restaurant> SearchAll();
    }

}
