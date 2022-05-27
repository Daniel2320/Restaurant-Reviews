using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantInfo
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    
        public string Email { get; set; }
        
        public string Password { get; set; }
        public User() {
            this.Email = Email;
            this.Password = Password;
           
        }
        
       
        public override string ToString()
        {
            return $"UserName: {this.Name}\nEmail: {this.Email}\nPassword: {this.Password}";
        }

    }
}
