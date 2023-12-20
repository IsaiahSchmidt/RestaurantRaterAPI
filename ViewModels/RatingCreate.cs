using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.ViewModels
{
    public class RatingCreate
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "value can only be from 0.0 - 10.0")]
        public double FoodScore { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "value can only be from 0.0 - 10.0")]
        public double EnvironmentScore { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "value can only be from 0.0 - 10.0")]
        public double CleanlinessScore { get; set; }
    }
}