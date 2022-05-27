using RestaurantInfo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace RestuarantAPI.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IConfiguration configuration;
        public JWTManagerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            {"Admin", "Admin" },

        };
        public Tokens Authenticate(User user)
        {
            //checking if the user is available in the Dictionery which will from the database later
            if (!UsersRecords.Any(a => a.Key == user.Name && a.Value == user.Password))
            {
                return null;
            }
            // else we want generate JWT Token
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                            new Claim(ClaimTypes.Name, user.Name)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            Log.Information("Token Created");
            return new Tokens { Token = tokenhandler.WriteToken(token) };
        }
    }
}

