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
            return _db.Destinations.ToList();
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
    }
}