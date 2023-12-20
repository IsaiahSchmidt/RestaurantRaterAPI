using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.ViewModels
{
    public class RestaurantListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Rating {get; set;}
    }
}