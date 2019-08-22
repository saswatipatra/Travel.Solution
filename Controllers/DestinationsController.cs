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
    public class DestinationsController : ControllerBase
    {
        private TravelContext _db = new TravelContext();
        private static int page = 1;
        private static int size = 3;
        private static int count;
        private static int totalPages;
        private static int prevPage;
        private static int nextPage;

        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            Console.WriteLine("PAGE!!!!!!!!!!!!!!!! = " + page);
            var allDestinations = _db.Destinations
                .ToList();
            count = allDestinations.Count();
            totalPages = (int)Math.Ceiling(count / (float)size);
            var output = _db.Destinations
                .Take(size)
                .Include(destinations => destinations.Reviews)
                .ToList();
            return output;
        }

        // Get the next page
        [HttpGet("next/")]
        public ActionResult<IEnumerable<Destination>> GetNextPage()
        {
            Console.WriteLine("PAGE!!!!!!!!!!!!!!!! = " + page);
            nextPage = page < totalPages ? page + 1 : totalPages;
            var output= _db.Destinations
                .Include(destinations => destinations.Reviews)
                .Skip((nextPage - 1) * size)
                .Take(size)
                .ToList();
            if (page<totalPages)
            {
                page += 1;
            }
            
            return output;
        }

        // Get the previous page
        [HttpGet("prev/")]
        public ActionResult<IEnumerable<Destination>> GetPrevPage()
        {
            Console.WriteLine("PAGE!!!!!!!!!!!!!!!! = " + page);
            prevPage = page > 1 ? page - 1 : 1;
            var output= _db.Destinations
                .Include(destinations => destinations.Reviews)
                .Skip((prevPage - 1) * size)
                .Take(size)
                .ToList();
            if (page>1)
            {
                page -= 1;
            }
            
            return output;
        }
        // POST api/destinations
        [HttpPost]
        public void Post([FromBody] Destination destination)
        {
            _db.Destinations.Add(destination);
            _db.SaveChanges();
        }

        // GET api/destinations/1
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            return _db.Destinations
                .Include(destinations => destinations.Reviews)
                .FirstOrDefault(x => x.DestinationId == id);
        }

        // PUT api/destinations/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Destination destination)
        {
            destination.DestinationId = id;
            _db.Entry(destination).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/destinations/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisDestination = _db.Destinations.FirstOrDefault(x => x.DestinationId == id);
            _db.Destinations.Remove(thisDestination);
            _db.SaveChanges();
        }
        
        // get destination name by country name
        [HttpGet("country/{country}")]
        public ActionResult<IEnumerable<Destination>> Get (string country)
        {
            return _db.Destinations.Where(x => x.Country == country).ToList();
        }

        // get most popular travel destinations by overall rating 
        [HttpGet ("popular"), ActionName("Get")]
        public ActionResult<IEnumerable<Destination>> GetPopular()
        {
            return _db.Destinations.Where(x=>x.AvgRating>3).ToList();
        }
    }
}