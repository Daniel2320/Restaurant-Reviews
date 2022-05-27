using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantInfo
{
    public class Review
    {

        public Review() { }

        //Example of constructor overloading
 
        public Review(double rating, string note,  string name, string username, double average, int RestId)
        {
            this.Rating = rating;
            this.Note = note;
            this.RestId = RestId;
           
        }

        public int RestId { get; set; }

        
     
       public int ReviewId { get; set; }
        private double _rating;
        public double Rating
        {
            get => _rating;
            //For the setter, we are checking that the rating is between 1 and 5
            set
            {
                if (value <= 0 || value > 5)
                {
                    throw new Exception("Rating must be between 1 and 5");
                }
                this._rating = value;
            }
        }
        public string Note { get; set; }

        //override Review's ToString Method for me here
        //That outputs $"Rating: {review.Rating} \t Note: {review.Note}"
    
        public override string ToString()
        {
            return $"RestId:{RestId}\tRating: {this.Rating}\t Note: {this.Note}";
        }

    }
}
