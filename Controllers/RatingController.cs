using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantRaterAPI.Data;
using RestaurantRaterAPI.ViewModels;

namespace RestaurantRaterAPI.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
       private readonly RestaurantDbContext _context;

       public RatingController(RestaurantDbContext context)
       {
        _context = context;
       }

       [HttpGet]
       public async Task<IActionResult> GetRatings()
       {
            List<RatingListItem> ratingListItems = await _context.Ratings.Select(r=> 
                        new RatingListItem
                        {
                            Id = r.Id,
                            RestaurantName = r.Restaurant!.Name,
                            FoodScore = r.FoodScore,
                            EnvironmentScore = r.EnvironmentScore,
                            CleanlinessScore = r.CleanlinessScore
                        }).ToListAsync();

                        return Ok(ratingListItems);
       }

       [HttpPost]
       public async Task<IActionResult> AddRating(RatingCreate model)
       {
            if (ModelState.IsValid)
            {
                // manual mapping
                Rating rating = new Rating()
                {
                    RestaurantId = model.RestaurantId,
                    CleanlinessScore = model.CleanlinessScore,
                    EnvironmentScore = model.EnvironmentScore,
                    FoodScore = model.FoodScore
                };

                await _context.Ratings.AddAsync(rating);
                await _context.SaveChangesAsync();

                return Ok("Rating successfully added");
            }
            return BadRequest("Rating could not be added");
        }

        [HttpPut]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> UpdateRating(int ratingId, RatingEdit model)
        {
            if (ratingId == model.Id && ModelState.IsValid)
            {
                Rating ratingInDb = await _context.Ratings.Include(r=>r.Restaurant).SingleOrDefaultAsync(x=>x.Id == ratingId);

                if (ratingInDb is null)
                    return NotFound();
                else
                {
                    if(model.RestaurantId > 0)
                    {
                        ratingInDb.RestaurantId = model.RestaurantId;
                        ratingInDb.CleanlinessScore = model.CleanlinessScore;
                        ratingInDb.EnvironmentScore = model.EnvironmentScore;
                        ratingInDb.FoodScore = model.FoodScore;

                        await _context.SaveChangesAsync();
                        return Ok("rating successfully updated");
                    } 
                }
            }
            return BadRequest("rating could not be updated");
        }

        [HttpDelete]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> DeleteRating(int ratingId)
        {
             if (ratingId > 0)
            {
                Rating ratingInDb = await _context.Ratings.Include(r=>r.Restaurant).SingleOrDefaultAsync(x=>x.Id == ratingId);

                if (ratingInDb is null)
                    return NotFound();
                else
                {
                    _context.Ratings.Remove(ratingInDb);
                    await _context.SaveChangesAsync();
                    return Ok("rating successfully deleted");
                }
            }
            return BadRequest("rating could not be deleted");
        }
    }
}