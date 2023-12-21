using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Data;
using RestaurantRaterAPI.ViewModels;

namespace RestaurantRaterAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantDbContext _context;
    public RestaurantController(RestaurantDbContext context)
    {
        _context = context;
    }

    // Async GET endpoint
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        List<Restaurant> restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();

        //manual mapping -> from: List<Restaurant> to List<RestaurantListItem>
        List<RestaurantListItem> restaurantListItems = restaurants.Select(r => new RestaurantListItem
        {
            Id = r.Id,
            Name = r.Name,
            Rating = r.Rating
        }).ToList();

        return Ok(restaurants);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetRestaurantById(int id)
    {
        Restaurant? restaurant = await _context.Restaurants.Include(r => r.Ratings).FirstOrDefaultAsync(r => r.Id == id);
        // manual mapping
        if (restaurant != null)
        {
         RestaurantDetail restaurantDetail = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Address = restaurant.Address,
                OverallScore = restaurant.Rating,
                FoodRating = restaurant.FoodRating,
                CleanlinessRating = restaurant.CleanlinessRating,
                EnvironmentRating = restaurant.EnvironmentRating,
                IsRecommended = restaurant.IsRecommended
            };

            return Ok(restaurantDetail);
        }
        return NotFound();

    }

    // Async POST method
    [HttpPost]
    public async Task<IActionResult> AddRestaurant([FromForm] RestaurantCreate model)
    {
        if (ModelState.IsValid)
        {
            // manual mapping
            Restaurant restaurant = new Restaurant()
            {
                Name = model.Name,
                Address = model.Address
            };

            // add to database
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return Ok("Restaurant" + restaurant.Name + " was successfully created");
        }
        return BadRequest("Restaurant failed to add to database");
    }

    [HttpPut]
    [Route("/update restaurant/{restaurantId:int}")]
    public async Task<IActionResult> UpdateRestaurant(int restaurantId, RestaurantEdit model)
    {
        if (restaurantId == model.Id && ModelState.IsValid)
        {
            //find restaurant in db
            Restaurant restaurantInDb = await _context.Restaurants.FirstOrDefaultAsync(x=>x.Id == restaurantId);

            if (restaurantInDb != null)
            {
            //need to update restaurantInDb's data manually
            restaurantInDb.Name = model.Name;
            restaurantInDb.Address = model.Address;

            await _context.SaveChangesAsync();
            return Ok("Restaurant was successfully added");
            }
            return NotFound();
        }
        return BadRequest("restaurant failed to update");
    }

    [HttpDelete]
    [Route("/delete restaurant/{restaurantId:int}")]
    public async Task<IActionResult> DeleteRestaurant(int restaurantId)
    {
        if (restaurantId > 0)
        {
            //find restaurant in db
            Restaurant restaurantInDb = await _context.Restaurants.FirstOrDefaultAsync(x=>x.Id == restaurantId);

            if (restaurantInDb != null)
            {
                _context.Restaurants.Remove(restaurantInDb);

                await _context.SaveChangesAsync();
                return Ok("Restaurant was successfully deleted");
            }
            return NotFound();
        }
        return BadRequest("restaurant failed to delete");
    }

}