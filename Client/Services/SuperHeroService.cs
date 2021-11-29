using SuperHeroDatabase.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDatabase.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        public SuperHeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero superHero)
        {
            var result = await _httpClient.PostAsJsonAsync<SuperHero>($"api/superhero", superHero);
            var heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            return heroes;
        }
    }
}
