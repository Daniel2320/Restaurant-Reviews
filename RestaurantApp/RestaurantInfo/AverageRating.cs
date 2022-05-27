using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantInfo
{
    public class AverageRating
    {  
        public AverageRating() { }
        public AverageRating(string name, double average, int restId)
        {
            Average = this.Average;
            

        }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public double Average { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}\nAverage: {this.Average}";
        }

    }
}
