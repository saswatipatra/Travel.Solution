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

        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            
            return _db.Destinations
                .Include(destinations => destinations.Reviews)
                .ToList();
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
            return _db.Destinations.FirstOrDefault(x => x.DestinationId == id);
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
    }
}