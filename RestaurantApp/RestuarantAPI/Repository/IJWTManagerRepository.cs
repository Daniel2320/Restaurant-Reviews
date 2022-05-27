using RestaurantInfo;
namespace RestuarantAPI.Repository
{
    public interface IJWTManagerRepository
    {
        public Tokens Authenticate(User user);

    }
}
