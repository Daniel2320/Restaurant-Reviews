using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurantInfo
{
    public class Restaurant
    {
        public Restaurant()
        {
         
        }
      

        /// <summary>
        /// Converting Restaurant table's data row into Restaurant Object
        /// </summary>
        /// <param name="row">a data row from Restaurant object, must have id, name, city, state columns</param>
        public Restaurant(DataRow row)
        {
            
            this.Name = row["Name"].ToString() ?? "";
            this.City = row["City"].ToString() ?? "";
            this.State = row["State"].ToString() ?? "";
        }


       // public int RestId { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
                if (string.IsNullOrWhiteSpace(value))
                {
                    //we're checking whether this string is null or whitespace
                    throw new Exception("Name can't be empty");
                }
                //even if the string is not null or white space,
                //we can still check for the name's validity by using RegEx (Regular Expression)
                //Regular Expression is a way to pattern match a string for a certain condition
                //it has a confusing syntax, so I recommend looking up language specific RegEx reference page to build one
                else if (!pattern.IsMatch(value))
                {
                    throw new Exception("Restaurant name can only have alphanumeric characters, white space, !, ?, and '.");
                }
                else
                {
                    this._name = value;
                }
            }
        }

        public int RestId { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public double Average { get; set; }
        public override string ToString()
        {
            return $"Name: {this.Name}\nAddress: {this.Address}\t\tZipcode: {this.ZipCode}" +
                $" \nCity: {this.City} \t\tState: {this.State}";
        }

        /// <summary>
        /// Takes in Restaurant Table's DataRow and fills the columns with the Restaurant Instance's info
        /// </summary>
        /// <param name="row">Restaurant Table's DataRow pass by ref</param>
        public void ToDataRow(ref DataRow row)
        {
            row["Name"] = this.Name;
            row["City"] = this.City;
            row["State"] = this.State;
        }






        
    }
}
