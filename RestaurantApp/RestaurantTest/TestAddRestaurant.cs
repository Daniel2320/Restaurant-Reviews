using RestaurantBL;
using RestaurantInfo;
using Xunit;

namespace RestaurantTest
{
    public class TestAddRestaurant
    {
        [Fact]
        public void RestaurantTest()
        {
            var Obj = new Restaurant();
            Obj.Name = "Tess";
            Obj.State = "State";
            Obj.City = "City";
            Obj.Address = "Address";
            Obj.ZipCode = "123";

            Assert.Equal(Obj.Name, "Tess");
            Assert.Equal(Obj.State,"State");
            Assert.Equal(Obj.City ,"City");
            Assert.Equal(Obj.Address ,"Address");
            Assert.Equal(Obj.ZipCode,"123");
            Assert.Equal(Obj.ToString(), $"Name: Tess\nAddress: Address\t\tZipcode: 123 \nCity: City \t\tState: State");
        }
        [Fact]
        public void ReviewTest()
        {
            var Rev = new Review();
            Rev.RestId = 1;
           
            Rev.Rating = 1;
           
            Rev.Note = "THis Note";
            Assert.Equal(Rev.ToString(), $"Restaurant name: Restuarant Name\tUser: UserName\nRating: 1\tAverage Rating: 2.3 \t Note: THis Note\n");

        }
        [Fact]
        public void UserTest()
        {
            var User = new User();
            User.Name = "Tess";
            User.Email = "Email";
            User.Password = "Password";

            Assert.Equal(User.ToString(), $"UserName: Tess\nEmail: Email\nPassword: Password");
        }
    }
}