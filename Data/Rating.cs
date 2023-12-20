using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRaterAPI.Data
{
    public class Rating
    {
        [Key]
        public int Id {get; set;}


        public int RestaurantId {get; set;}

        [Required]
        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; }

        [Required]
        [Range(0,10)]
        public double FoodScore {get; set;}

        [Required]
        [Range(0,10)]
        public double EnvironmentScore {get; set;}

        [Required]
        [Range(0,10)]
        public double CleanlinessScore {get; set;}


        public double AverageRating
        {
            get
            {
                var totalScore = (FoodScore + EnvironmentScore + CleanlinessScore) / 3;
                return Math.Round(totalScore, 2);
            }
        }
    }
}