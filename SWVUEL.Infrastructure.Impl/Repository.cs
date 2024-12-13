using Microsoft.EntityFrameworkCore;
using SWVUEL.Infrastructure.Contracts;
using SWVUEL.Infrastructure.Contracts.Entities;
using SWVUEL.Infrastructure.Impl.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWVUEL.Infrastructure.Impl
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly StarshipDbContext _context;

        public Repository(HttpClient httpClient, StarshipDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
            _httpClient.BaseAddress = new Uri("https://swapi.dev/api/");

        }

        public async Task<StarshipApiResponseEntity> GetStarshipAsync()
        {
            var response = await _httpClient.GetStringAsync("starships/?format=json");
            return JsonSerializer.Deserialize<StarshipApiResponseEntity>(response);

        }

        public async Task<StarshipApiResponseEntity> GetStarshipFromApiAsync()
        {
            var response = await _httpClient.GetStringAsync("starships/?format=json");
            return JsonSerializer.Deserialize<StarshipApiResponseEntity>(response);
        }

        public async Task UpsertStarshipAsync(Starship starship)
        {
            var existingStarship = await _context.Starships
                .AsNoTracking() 
                .FirstOrDefaultAsync(p => p.url == starship.url);

            if (existingStarship == null)
            {
                _context.Starships.Add(starship);
            }
            else
            {
                _context.Entry(existingStarship).State = EntityState.Detached;

                existingStarship.name = starship.name;
                existingStarship.model = starship.model;
                existingStarship.manufacturer = starship.manufacturer;
                existingStarship.cost_in_credits = starship.cost_in_credits;
                existingStarship.length = starship.length;
                existingStarship.crew = starship.crew;
                existingStarship.passengers = starship.passengers;
                existingStarship.starship_class = starship.starship_class;
                existingStarship.url = starship.url;

                _context.Starships.Update(existingStarship);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<List<string>> GetAllStarshipNamesAsync()
        {
            return await _context.Starships
                .Select(p => p.name)
                .ToListAsync();
        }

        public async Task<bool> UpdateStarshipNameAsync(int id, string newName)
        {
            var starship = await _context.Starships.FirstOrDefaultAsync(p => p.id == id);
            if (starship == null)
            {
                return false; 
            }

            starship.name = newName;
            await _context.SaveChangesAsync();
            return true; 
        }


        public async Task<Starship> GetStarshipByIdAsync(int id)
        {
            return await _context.Starships.FirstOrDefaultAsync(s => s.id == id);
        }

        public async Task<bool> UpdateStarshipNameAndModelAsync(int id, string newName, string newModel)
        {
            var starship = await _context.Starships.FirstOrDefaultAsync(s => s.id == id);

            if (starship == null)
            {
                return false; 
            }

            starship.name = newName;
            starship.model = newModel;

            await _context.SaveChangesAsync();
            return true;
        }







    }
}
