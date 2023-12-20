using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.ViewModels
{
    public class RatingListItem
    {
        public int Id {get; set;}

        public string RestaurantName { get; set; } = string.Empty;

        public double FoodScore {get; set;}
        public double EnvironmentScore {get; set;}
        public double CleanlinessScore {get; set;}
    }
}