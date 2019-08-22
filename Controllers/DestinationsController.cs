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
        public static int page = 1;
        public static int size = 3;
        public static int count;
        public static int totalPages;
        public static int prevPage = page > 1 ? page - 1 : 1;
        public static int nextPage;

        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            var allDestinations = _db.Destinations
                .ToList();
            count = allDestinations.Count();
            Console.WriteLine("COUNT!!!!!!!!!!!!!!! " + count);

            var output = _db.Destinations
                .Take(size)
                .Include(destinations => destinations.Reviews)
                .ToList();
            return output;
        }

        [HttpGet("next/")]
        public ActionResult<IEnumerable<Destination>> GetNextPage()
        {
            totalPages = (int)Math.Ceiling(count / (float)size);
            nextPage = page < totalPages ? page + 1 : totalPages;
            Console.WriteLine("TOTALPAGES!!!!!!!!!!!!!!! " + totalPages);
            Console.WriteLine("NEXTPAGE!!!!!!!!!!!!!!! " + nextPage);

            var output= _db.Destinations
                .Include(destinations => destinations.Reviews)
                .Skip((nextPage - 1) * size)
                .Take(size)
                .ToList();
            page += 1;
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