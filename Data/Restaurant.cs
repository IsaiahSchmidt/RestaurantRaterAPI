using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RestaurantRaterAPI.Data
{
    public class Restaurant
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required] // not null
        [MaxLength(100)] // nvchar(100)
        public string Name { get; set; } = string.Empty;


        [Required, MaxLength(100)] // attributes can go in the same brackets
        public string Location { get; set; } = string.Empty;

        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public double Rating
        {
            get
            {
                double totalAverageRating = 0;
                foreach (var Rating in Ratings)
                {
                    totalAverageRating += Rating.AverageRating;
                }

                var result = (Ratings.Count > 0)
                              ? totalAverageRating / Ratings.Count
                              : 0;

                return Math.Round(result, 2);
            }
        }

        public double FoodRating
        {
            get
            {
                var totalFoodRating = (Ratings.Count() > 0)
                                        ? Ratings.Sum(r => r.FoodScore) / Ratings.Count()
                                        : 0;

                return Math.Round(totalFoodRating, 2);
            }
        }
        public double CleanlinessRating
        {
            get
            {
                var totalCleanlinessRating = (Ratings.Count() > 0)
                                        ? Ratings.Sum(r => r.CleanlinessScore) / Ratings.Count()
                                        : 0;

                return Math.Round(totalCleanlinessRating, 2);
            }
        }
        public double EnvironmentRating
        {
            get
            {
                var totalEnvironmentRating = (Ratings.Count() > 0)
                                        ? Ratings.Sum(r => r.EnvironmentScore) / Ratings.Count()
                                        : 0;

                return Math.Round(totalEnvironmentRating, 2);
            }
        }
        public bool IsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }
    }
}