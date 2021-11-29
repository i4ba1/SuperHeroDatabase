using Microsoft.AspNetCore.Mvc;
using SuperHeroDatabase.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> comics = new List<Comic>
        {
            new Comic { Name = "Marvel"},
            new Comic { Name = "DC"},
        };

        List<SuperHero> heroes = new List<SuperHero> 
        {
            new SuperHero { Id=1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic = comics[0]},
            new SuperHero { Id=2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = comics[1]},
        };

        [HttpGet]
        public async Task<ActionResult> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSuperHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if(hero ==  null)
            {
                return NotFound("Super Hero wasn't found. Too Bad.!!");
            }

            return Ok(hero);
        }

        [HttpPost]
        [Route("/createSuperHero")]
        public async Task<IActionResult> CreateSuperHero(SuperHero superHero)
        {
            heroes.Add(superHero);
            return Ok(heroes);
        }
    }
}
