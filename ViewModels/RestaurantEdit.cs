using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.ViewModels
{
    public class RestaurantEdit
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot excede 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150, ErrorMessage = "Address cannot excede 150 characters")]
        public string Address { get; set; } = string.Empty;
    }
}