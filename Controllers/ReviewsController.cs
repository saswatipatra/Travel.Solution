using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private TravelContext _db = new TravelContext();

        // GET api/reviews
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            return _db.Reviews
                .Include(reviews => reviews.Destination)
                .ToList();
        }

        // POST api/reviews
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        // GET api/reviews/1
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
        }
    }
}